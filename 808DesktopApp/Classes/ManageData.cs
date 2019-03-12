using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _808DesktopApp.Classes
{
    public class ManageData
    {
        public static bool isOffLine = false;
        static Classes.DbConnection db = new Classes.DbConnection();

        public static UserLogin login(string username, string password)
        {
            UserLogin resultLogin = null;
            try
            {
                resultLogin = Classes.WebService.login(username, password);
                if (!string.IsNullOrEmpty(resultLogin.sessid))
                {
                    createSystemInfo(ref resultLogin);
                    resultLogin.user.password = password;
                    db.insertUser(resultLogin.user);
                    db.insertProfile(resultLogin.profile);
                }
            }
            catch (Exception)
            {
                var user = db.getUser();
                var profile = db.getProfile();
                if (user != null && profile != null)
                {
                    if (user.name == username && user.password == password)
                        resultLogin = new UserLogin() { user = user, profile = profile };
                }
                isOffLine = true;
            }
            return resultLogin;
        }

        public static MyProduct myProducts(UserLogin userLogin)
        {
            MyProduct myProducts = null;
            try
            {
                if (!string.IsNullOrEmpty(userLogin.sessid))
                {
                    myProducts = Classes.WebService.myProducts(userLogin);
                    db.insertMyProduct(myProducts);
                }
                myProducts = db.getMyProduct();
            }
            catch (Exception)
            {
                myProducts = db.getMyProduct();
                isOffLine = true;
            }

            return myProducts;
        }

        public static LastContent lastContent()
        {
            LastContent lastContent = null;
            try
            {
                if (!isOffLine)
                {
                    lastContent = Classes.WebService.lastContent();
                    db.insertLastContent(lastContent);
                }
                lastContent = db.getLastContent();
            }
            catch (Exception)
            {
                lastContent = db.getLastContent();
                isOffLine = true;
            }
            return lastContent;
        }

        public static LastContent suggestion(UserLogin userLogin)
        {
            LastContent suggestion = null;

            try
            {
                if (!string.IsNullOrEmpty(userLogin.sessid))
                {
                    suggestion = Classes.WebService.suggestion(userLogin);
                    db.insertSuggestion(suggestion);
                }
                suggestion = db.getSuggestion();
            }
            catch (Exception)
            {
                suggestion = db.getSuggestion();
                isOffLine = true;
            }

            return suggestion;
        }

        public static UserLogin userInfo(UserLogin userLogin)
        {
            UserLogin resultLogin = null;
            try
            {
                resultLogin = Classes.WebService.userInfo(userLogin);
                if (!string.IsNullOrEmpty(resultLogin.sessid))
                {
                    db.insertUser(resultLogin.user);
                    db.insertProfile(resultLogin.profile);
                }
            }
            catch (Exception)
            {
                var user = db.getUser();
                var profile = db.getProfile();
                if (user != null && profile != null)
                {
                    resultLogin = new UserLogin() { user = user, profile = profile };
                }
                isOffLine = true;
            }
            return resultLogin;
        }

        public static Bookmark bookmark(UserLogin userLogin)
        {
            Bookmark myBookmarks = null;
            try
            {
                if (!string.IsNullOrEmpty(userLogin.sessid))
                {
                    myBookmarks = Classes.WebService.myBookmarks(userLogin);
                    db.insertBookmark(myBookmarks);
                }
                myBookmarks = db.getBookmark();
            }
            catch (Exception)
            {
                myBookmarks = db.getBookmark();
                isOffLine = true;
            }

            return myBookmarks;
        }

        public static void logout(UserLogin userLogin)
        {
            try
            {
                if (userLogin != null && userLogin.systemInfoId != 0)
                    deleteSystemInfo(userLogin);
                if (userLogin != null && !string.IsNullOrEmpty(userLogin.session_name))
                    Classes.WebService.logout(userLogin);
            }
            catch (Exception)
            {
                isOffLine = true;
            }

        }

        public static bool OffLineApp()
        {
            isOffLine = WebService.CheckForInternetConnection();
            return isOffLine;
        }

        private static void createSystemInfo(ref UserLogin userLogin)
        {
            try
            {
                var systemInfo = new SystemInfo
                {
                    cpu_model = Helper.getCPUName(),
                    cpu_serial = Helper.getCPUSerial(),
                    hdd_serial = Helper.getHDDSerial(),
                    main_board_serial = Helper.getMainbord()
                };
                userLogin.systemInfoId = Classes.WebService.createSystem_Info(systemInfo, userLogin);
            }
            catch (Exception)
            {
                userLogin.systemInfoId = 0;
            }
        }

        private static void deleteSystemInfo(UserLogin userLogin)
        {
            try
            {
                Classes.WebService.deleteSystem_Info(userLogin);
            }
            catch (Exception)
            {
            }
        }




    }
}
