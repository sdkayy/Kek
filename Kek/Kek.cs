namespace Kek
{
    public class Kek
    {
        /// <summary>
        /// IGSessionIDs are what are used to complete tasks on IG.
        /// </summary>
        public static string IGSessionIDLogin, IGSessionIDRegister;

        /// <summary>
        /// Set to true to see the output as it goes.
        /// </summary>
        public static bool debug;

        /// <summary>
        /// ID of currently logged on user.
        /// </summary>
        public static string LoggedOnID;

        /// <summary>
        /// Kek Constructor
        /// </summary>
        public Kek() { /* Empty Constructor, oops */ }

        /// <summary>
        /// Report types
        /// </summary>
        public enum ReportType
        {
            /// <summary>
            /// Spam Post
            /// </summary>
            Spam = 1,
            /// <summary>
            /// Self-Harm
            /// </summary>
            Harm = 2,
            /// <summary>
            /// Drug use
            /// </summary>
            Drugs = 3,
            /// <summary>
            /// Nudity or Porn
            /// </summary>
            Nudity = 4,
            /// <summary>
            /// Graphic Violence(Gore)
            /// </summary>
            Violence = 5,
            /// <summary>
            /// Hate Speech
            /// </summary>
            Hate = 6,
            /// <summary>
            /// Bullying or Harassment
            /// </summary>
            Bullying = 7
        }
    }
}
