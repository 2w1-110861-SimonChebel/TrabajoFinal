using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Easy_Stock.Entidades
{
    public static class Bootstrap
    {
        public static string alertPrimary { get;} = "alert alert-primary";
        public static string alertSecondary { get; } = "alert alert-secondary";
        public static string alertSucces { get;} = "alert alert-succes";
        public static string alertDanger { get;} = "alert alert-danger";
        public static string alertWarning { get;} = "alert alert-warning";
        public static string alertDark { get; } = "alert alert-dark";
        public static string alertInfo { get; } = "alert alert-info";

        public static string alertPrimaryDismissable { get; } = "alert alert-primary alert-dismissible fade show";
        public static string alertSecondaryDismissable { get; } = "alert alert-secondary alert-dismissible fade show";
        public static string alertSuccesDismissable { get; } = "alert alert-success alert-dismissible fade show";
        public static string alertDangerDismissable { get; } = "alert alert-danger alert-dismissible fade show";
        public static string alertWarningDismissable { get; } = "alert alert-warning alert-dismissible fade show";
        public static string alertDarkDismissable { get; } = "alert alert-dark alert-dismissible fade show";
        public static string alertInfoDismissable{ get; } = "alert alert-info alert-dismissible fade show";
    }
}