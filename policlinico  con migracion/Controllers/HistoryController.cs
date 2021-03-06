﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using policlinico__con_migracion.Models;

using TrackerEnabledDbContext.Common.Models;



namespace policlinico__con_migracion.Controllers
{
	public class HistoryController : Controller
	{
		//Todo: desactivado por q no esta activo el contexto
		// GET: /History/
		public ActionResult Index()
        {
            var db = new Models.ApplicationDbContext();
            var data = db.AuditLog
                .OrderByDescending(x => x.EventDateUTC)
                .ToList();
            List<BaseHistoryVM> vm = ConvertToHistoryViewModel(data);

            return View(vm);
        }

        private static List<BaseHistoryVM> ConvertToHistoryViewModel(IEnumerable<AuditLog> data)
        {
            var vm = new List<BaseHistoryVM>();

            foreach (var log in data)
            {
                switch (log.EventType)
                {
                    case EventType.Added: // added
                        vm.Add(new AddedHistoryVM
                        {
                            Date = log.EventDateUTC.ToLocalTime(),
                            LogId = log.AuditLogId,
                            RecordId = log.RecordId,
                            TypeFullName = log.TypeFullName,
                            UserName = log.UserName,
                            Details = log.LogDetails.Select(x => new LogDetail { PropertyName = x.PropertyName, NewValue = x.NewValue })
                        });
                        break;

                    case EventType.Deleted: //deleted
                        vm.Add(new DeletedHistoryVM
                        {
                            Date = log.EventDateUTC.ToLocalTime(),
                            LogId = log.AuditLogId,
                            RecordId = log.RecordId,
                            TypeFullName = log.TypeFullName,
                            UserName = log.UserName,
                            Details = log.LogDetails.Select(x => new LogDetail { PropertyName = x.PropertyName, OldValue = x.OriginalValue })
                        });
                        break;

                    case EventType.Modified: //modified
                        vm.Add(new ChangedHistoryVM
                        {
                            Details = log.LogDetails.Select(x => new LogDetail { PropertyName = x.PropertyName, NewValue = x.NewValue, OldValue = x.OriginalValue }),
                            Date = log.EventDateUTC.ToLocalTime(),
                            LogId = log.AuditLogId,
                            RecordId = log.RecordId,
                            TypeFullName = log.TypeFullName,
                            UserName = log.UserName,
                        });
                        break;
                    case EventType.SoftDeleted: //SoftDeleted
                        vm.Add(new SoftDeletedHistoryVM
                        {
                            Details = log.LogDetails.Select(x => new LogDetail { PropertyName = x.PropertyName, NewValue = x.NewValue, OldValue = x.OriginalValue }),
                            Date = log.EventDateUTC.ToLocalTime(),
                            LogId = log.AuditLogId,
                            RecordId = log.RecordId,
                            TypeFullName = log.TypeFullName,
                            UserName = log.UserName,
                        });
                        break;
                    case EventType.UnDeleted: //UnDeleted
                        vm.Add(new UndeletedHistoryVM
                        {
                            Details = log.LogDetails.Select(x => new LogDetail { PropertyName = x.PropertyName, NewValue = x.NewValue, OldValue = x.OriginalValue }),
                            Date = log.EventDateUTC.ToLocalTime(),
                            LogId = log.AuditLogId,
                            RecordId = log.RecordId,
                            TypeFullName = log.TypeFullName,
                            UserName = log.UserName,
                        });
                        break;
                }

            }

            return vm;
        }

       public PartialViewResult EntityHistory(string typeFullName, object entityId)
        {
            var db = new ApplicationDbContext();
            var auditLogs = db.GetLogs(typeFullName, entityId)
                .OrderByDescending(x=>x.EventDateUTC);
            var viewModels = ConvertToHistoryViewModel(auditLogs);

            ViewBag.EntityType = typeFullName;
            ViewBag.EntityId = entityId;

            return PartialView("_EntityHistory", viewModels);
        }
	}
}