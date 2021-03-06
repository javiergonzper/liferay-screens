﻿using Foundation;
using LiferayScreens;
using System;
using UIKit;

namespace ShowcaseiOS.ViewController
{
    public partial class DDLListViewController : UIViewController, IDDLListScreenletDelegate
    {
        public DDLListViewController(IntPtr handle) : base(handle) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.ddlListScreenlet.RecordSetId = LiferayServerContext.LongPropertyForKey("ddlListRecordSetId");
            this.ddlListScreenlet.LabelFields = LiferayServerContext.StringPropertyForKey("ddlListLabelFields");

            this.ddlListScreenlet.Delegate = this;
        }

        /* IDDLListScreenletDelegate */

        [Export("screenlet:onDDLListError:")]
        public virtual void OnDDLListError(DDLListScreenlet screenlet, NSError error)
        {
            Console.WriteLine($"DDLList error: {error.DebugDescription}");
        }

        [Export("screenlet:onDDLListResponseRecords:")]
        public virtual void OnDDLListResponseRecords(DDLListScreenlet screenlet, DDLRecord[] records)
        {
            Console.WriteLine($"DDLList response: {records.Length} records");
        }

        [Export("screenlet:onDDLSelectedRecord:")]
        public virtual void OnDDLSelectedRecord(DDLListScreenlet screenlet, DDLRecord record)
        {
            Console.WriteLine($"DDLList selected record: {record.Attributes}");
        }
    }
}
