using EleWise.ELMA.ComponentModel;
using EleWise.ELMA.Tasks.Models;
using EleWise.ELMA.Web.Mvc.ExtensionPoints.ActionItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExtrasTaskExt.Web.Components
{
    /// <summary>
    /// Точка расширения для заполнения подраздела
    /// </summary>
    [ExtensionPoint(ServiceScope.Shell)]
    public interface ITaskActionExtension
    {
        /// <summary>
        /// Получить список кнопок по задаче
        /// </summary>
        /// <param name="task">Задача</param>
        /// <returns></returns>
        IEnumerable<IActionItem> GetItems(ITaskBase task);
    }
}
