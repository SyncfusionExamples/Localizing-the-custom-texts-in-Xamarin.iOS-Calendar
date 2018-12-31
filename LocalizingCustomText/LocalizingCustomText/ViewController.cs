using System;
using Foundation;
using Syncfusion.SfCalendar.iOS;
using UIKit;

namespace LocalizingCustomText
{
    public partial class ViewController : UIViewController
    {
        SFCalendar sfcalendar;
        NSMutableArray calendarAppointmentCollection;
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            sfcalendar = new SFCalendar();
            calendarAppointmentCollection = new NSMutableArray();
            sfcalendar.EnableInLine = true;
            sfcalendar.Locale = new NSLocale("fr");
            sfcalendar.Frame = new CoreGraphics.CGRect(0, 20, this.View.Frame.Width, this.View.Frame.Height);

            NSCalendar calendar = NSCalendar.CurrentCalendar;

            NSDate today = new NSDate();

            NSDateComponents startDateComponents = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            startDateComponents.Hour = 10;
            startDateComponents.Minute = 0;
            startDateComponents.Second = 0;

            NSDateComponents endDateComponents = calendar.Components(NSCalendarUnit.Year | NSCalendarUnit.Month | NSCalendarUnit.Day, today);
            endDateComponents.Hour = 12;
            endDateComponents.Minute = 0;
            endDateComponents.Second = 0;

            NSDate startDate = calendar.DateFromComponents(startDateComponents);

            NSDate endDate = calendar.DateFromComponents(endDateComponents);

            SFAppointment calendarAppointment = new SFAppointment();
            calendarAppointment.StartTime = startDate;
            calendarAppointment.EndTime = endDate;
            calendarAppointment.Subject = (NSString)"Meeting";
            calendarAppointment.Location = (NSString)"Chennai";
            calendarAppointment.AppointmentBackground = UIColor.Red;
            calendarAppointment.AllDay = true;

            calendarAppointmentCollection.Add(calendarAppointment);

            sfcalendar.Appointments = calendarAppointmentCollection;

            View.AddSubview(sfcalendar);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
