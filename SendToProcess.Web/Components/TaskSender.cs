using EleWise.ELMA;
using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Tasks.Models;
using EleWise.ELMA.Web.Mvc.ExtensionPoints.ActionItems;
using EleWise.ELMA.Web.Mvc.Models.ActionItems.Toolbar;
using EleWise.ELMA.Workflow.Managers;
using ExtrasTaskExt.Web.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendToProcess.Web.Components
{
    [Component]
    public class TaskSender : ITaskActionExtension
    {
        public IEnumerable<IActionItem> GetItems(ITaskBase task)
        {
            //надо получить список запускаемых процессов
            //var startableProcesses = ProcessHeaderManager.Instance.GetStartableProcesses();

            var item = new ActionToolbarItem()
            {
                Text = SR.T("Отправить в процесс")
            };

            return new ActionToolbarItem[] { item };
        }

    }
}
