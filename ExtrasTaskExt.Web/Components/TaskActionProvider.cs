using EleWise.ELMA;
using EleWise.ELMA.BPM.Web.Tasks.Models;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.Web.Mvc.ExtensionPoints.ActionItems;
using EleWise.ELMA.Web.Mvc.Html;
using EleWise.ELMA.Web.Mvc.Html.Toolbar;
using EleWise.ELMA.Web.Mvc.Models.ActionItems;
using EleWise.ELMA.Web.Mvc.Models.ActionItems.Toolbar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExtrasTaskExt.Web.Components
{
    [Component(Type = ComponentType.Server)]
    public class TaskActionProvider : IActionItemProvider
    {
        //коллекция для хранения списка кнопок
        public IEnumerable<ITaskActionExtension> Extensions { get; set; }

        /// <summary>
        /// Получить список активных элементов для анализа в других точках
        /// </summary>
        /// <param name="rootItem">Корневой активный элемент</param>
        /// <param name="htmlHelper">Текущий хэлпер</param>
        /// <returns></returns>
        public IEnumerable<IActionItem> GetItems(IActionItem rootItem, HtmlHelper htmlHelper)
        {
            //если корневой элемент нул или уид не равен дефолтному или вью дата нул - выход
            if (rootItem == null) yield break;
            if (rootItem.Uid != ToolbarBuilder.DefaultActionsToolbarUid) yield break;
            if (htmlHelper.ViewData == null) yield break;

            //получаем данные задачи, не получили - выход
            var task = htmlHelper.ViewData.Model as TaskViewModel;
            if (task == null) yield break;

            //получаем список кнопок
            var list = new ActionItemList();
            var actions = Extensions.Select(ext => ext.GetItems(task.Entity));
            foreach (var action in actions)
            {
                foreach (var actionItem in action)
                {
                    list.Add(actionItem);
                }
            }

            var item = new ActionToolbarItem
            {
                Text = SR.T("Дополнительно")
            };
            item.Items.AddSequense(list);

            yield return item;
        }

        /// <summary>
        /// добавляет новый элемент (IActionItem) в тулбар
        /// </summary>
        /// <param name="rootItem">Корневой активный элемент, например, меню или тулбар</param>
        /// <param name="htmlHelper">Текущий хэлпер</param>
        public void InsertItems(IActionItem rootItem, HtmlHelper htmlHelper)
        {
            //если корневой элемент нул или уид не равен дефолтному - выход
            if (rootItem == null) return;
            if (rootItem.Uid != ToolbarBuilder.DefaultActionsToolbarUid) return;

            //указываем куда встраиваемся
            var group = rootItem.Items.FirstOrDefault(item => item != null && item.Uid == "actions");
            if (group != null)
            {
                var actions = group.Items.FirstOrDefault(item => item.Uid == "toolbar-button-actions");
                if (actions != null)
                {
                    var askQuestion = actions.Items.FirstOrDefault(item => item.Uid == "toolbar-click-addquestion");
                    if (askQuestion != null)
                    {
                        var index = actions.Items.IndexOf(askQuestion);
                        GetItems(rootItem, htmlHelper).ForEach(it => askQuestion.Items.Add(it));
                    }
                }
            }
        }

    }
}
