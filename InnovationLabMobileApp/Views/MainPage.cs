using System;
using InnovationLabMobileApp.Models;
using Xamarin.Forms;

namespace InnovationLabMobileApp.Views
{
    public class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            Master = new MenuPage();
            Detail = new LandingPage();
        }
    }

    public class MainAboutFDAPage : MasterDetailPage
    {
        public MainAboutFDAPage()
        {
            Master = new MenuPage();
            Detail = new AboutFDAPage();
        }
    }
    public class MainLabRegPage : MasterDetailPage
    {
        public MainLabRegPage()
        {
            Master = new MenuPage();
            Detail = new LabRegistrationPage();
        }
    }
    public class MainEventRegPage : MasterDetailPage
    {
        public MainEventRegPage()
        {
            Master = new MenuPage();
            Detail = new EventRegistrationPage();
        }
    }
    public class MainPreviousVisitorsPage : MasterDetailPage
    {
        public MainPreviousVisitorsPage()
        {
            Master = new MenuPage();
            Detail = new PreviousVisitors();
        }
    }

    public class MainScanPage : MasterDetailPage
    {
        public MainScanPage()
        {
            Master = new MenuPage();
            Detail = new ScanPage();
        }
    }

    public class MainOurWorkPage : MasterDetailPage
    {
        public MainOurWorkPage()
        {
            Master = new MenuPage();
            Detail = new OurWorkPage();
        }
    }
    public class MainActivityPage : MasterDetailPage
    {
        public MainActivityPage()
        {
            Master = new MenuPage();
            Detail = new ActivitiesPage();
        }
    }
    public class MainHoursPage : MasterDetailPage
    {
        public MainHoursPage()
        {
            Master = new MenuPage();
            Detail = new HoursofOperationPage();
        }
    }
    public class MainInnovatePage : MasterDetailPage
    {
        public MainInnovatePage()
        {
            Master = new MenuPage();
            Detail = new InnovateExperiencePage();
        }
    }

    public class MainPrototypePage : MasterDetailPage
    {
        public MainPrototypePage()
        {
            Master = new MenuPage();
            Detail = new PrototypesPage();
        }
    }
    public class MainWhitePaperPage : MasterDetailPage
    {
        public MainWhitePaperPage()
        {
            Master = new MenuPage();
            Detail = new WhitePapersPage();
        }
    }
    public class MainIdeationPage : MasterDetailPage
    {
        public MainIdeationPage()
        {
            Master = new MenuPage();
            Detail = new IdeationandInnovationpage();
        }
    }
    public class MainTechSurvPage : MasterDetailPage
    {
        public MainTechSurvPage()
        {
            Master = new MenuPage();
            Detail = new TechnologySurveillancePage();
        }
    }
    public class MainWorkshopsPage : MasterDetailPage
    {
        public MainWorkshopsPage()
        {
            Master = new MenuPage();
            Detail = new InnovateWorkshops();
        }
    }
    public class MainTechTalkxPage : MasterDetailPage
    {
        public MainTechTalkxPage()
        {
            Master = new MenuPage();
            Detail = new TechTalkx();
        }
    }
    public class MainAskExpertPage : MasterDetailPage
    {
        public MainAskExpertPage()
        {
            Master = new MenuPage();
            Detail = new AskTheExpert();
        }
    }
    public class MainInnovateTodayPage : MasterDetailPage
    {
        public MainInnovateTodayPage()
        {
            Master = new MenuPage();
            Detail = new InnovateTodayConferencePage();
        }
    }

    public class MainPrototypesInfo : MasterDetailPage
    {
        public MainPrototypesInfo(Prototype Prototype)
        {
            Master = new MenuPage();
            Detail = new PrototypesInfo(Prototype);
        }
    }

    public class MainWhitePapersInfo : MasterDetailPage
    {
        public MainWhitePapersInfo(WhitePaper WhitePaper)
        {
            Master = new MenuPage();
            Detail = new WhitePapersInfo(WhitePaper);
        }
    }

    public class MainTechnologySurvInfo : MasterDetailPage
    {
        public MainTechnologySurvInfo(TechSurv TechSurv)
        {
            Master = new MenuPage();
            Detail = new TechnologySurvInfo(TechSurv);
        }
    }

    public class MainLabRegistrationCompletePage : MasterDetailPage
    {
        public MainLabRegistrationCompletePage(string firstname, string Page)
        {
            Master = new MenuPage();
            Detail = new LabRegistrationCompletePage(firstname, Page);
        }
    }

    public class MainSurveySubmitPage : MasterDetailPage
    {
        public MainSurveySubmitPage()
        {
            Master = new MenuPage();
            Detail = new SurveySubmitPage();
        }
    }
}

