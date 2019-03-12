using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace _808DesktopApp.Classes
{
    public class DbConnection
    {
        static bool setpass = true;
        static string pathDataBase = "DesktopDb.db";
        static string passwordDataBase = Helper.getCPUSerial() + ";";
        static string connectionString = "Data Source=" + pathDataBase + ";Version=3;" + (setpass ? "Password =" + passwordDataBase : "");
        SQLiteConnection m_dbConnection;

        void initDB()
        {
            try
            {
                if (!System.IO.File.Exists(pathDataBase))
                {
                    SQLiteConnection.CreateFile(pathDataBase);
                    m_dbConnection = new SQLiteConnection(connectionString);
                    if (setpass)
                        m_dbConnection.SetPassword(passwordDataBase);
                    m_dbConnection.Open();
                    var createTables =
                    "CREATE TABLE[File](  [title] NVARCHAR,   [url] NVARCHAR,   [filesize] INT,   [name] NVARCHAR,   [new_name] NVARCHAR,  [password] NVARCHAR,   [password_key] NVARCHAR,   [pid] INT);" +
                    "CREATE TABLE[LastContent](  [nid] INT,   [title] NVARCHAR,   [url] NVARCHAR,   [picture] NVARCHAR,   [local_picture] NVARCHAR,   [type] NVARCHAR);" +
                    "CREATE TABLE[Product](  [id] INT,   [nid] INT,   [title] NVARCHAR,   [author] NVARCHAR,   [order_time] INT,   [price] INT,   [type] NVARCHAR,   [picture] NVARCHAR,   [local_picture] NVARCHAR);" +
                    "CREATE TABLE[Profile](  [pid] INT,   [full_name] NVARCHAR,   [about_me] NVARCHAR,   [skills] NVARCHAR,   [university] NVARCHAR,   [education_field] NVARCHAR,   [education_degree] NVARCHAR,   [mobile] NVARCHAR,   [job] NVARCHAR,   [user_point] NVARCHAR,   [background_image] NVARCHAR,   [background_local_image] NVARCHAR);" +
                    "CREATE TABLE[Suggestion](  [nid] INT,   [title] NVARCHAR,   [url] NVARCHAR,  [picture] NVARCHAR,   [local_picture] NVARCHAR,   [type] NVARCHAR);" +
                    "CREATE TABLE[User](  [uid] INT,   [privatemsg_disabled] BOOL,   [picture] NVARCHAR,   [local_picture] NVARCHAR,   [name] NVARCHAR,   [mail] NVARCHAR,   [login] NVARCHAR,   [created] NVARCHAR,   [password] NVARCHAR);" +
                    "CREATE TABLE[Bookmark]([nid] INT,   [title] NVARCHAR,   [url] NVARCHAR,  [picture] NVARCHAR,   [local_picture] NVARCHAR,   [type] NVARCHAR);";

                    SQLiteCommand command = new SQLiteCommand(createTables, m_dbConnection);
                    command.ExecuteNonQuery();
                    m_dbConnection.Close();
                }
                else
                {
                    try
                    {
                        m_dbConnection = new SQLiteConnection(connectionString);
                        m_dbConnection.Open();
                        m_dbConnection.Close();
                    }
                    catch (Exception)
                    {
                        System.IO.File.Delete(pathDataBase);
                        initDB();
                    }
                }
            }
            catch (Exception t)
            {
                //throw t;
            }
        }

        public DbConnection()
        {
            initDB();
            m_dbConnection = new SQLiteConnection(connectionString);
            m_dbConnection.Open();
        }

        ~DbConnection()
        {
            m_dbConnection.Close();
        }

        public void Dispose()
        {
            m_dbConnection.Close();
        }


        #region MyProduct

        public bool insertMyProduct(MyProduct myProducts)
        {
            try
            {
                deleteMyProduct();
                int index = 1;
                foreach (var product in myProducts.product)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(product.picture))
                        local_picture = Helper.saveImage(product.picture);

                    var sql = "INSERT INTO Product (id,nid, title,author,picture,local_picture,order_time,price,type) " +
                                    "values ('" + index + "','" + product.nid + "','" + product.title + "','" + product.author + "','" + product.picture + "','" + local_picture + "','" + product.order_time + "'," + product.price + ",'product')";
                    SQLiteCommand commandp = new SQLiteCommand(sql, m_dbConnection);
                    commandp.ExecuteNonQuery();
                    commandp.Dispose();

                    var pid = index;
                    sql = string.Empty;
                    foreach (var file in product.files)
                    {
                        var key = Helper.RandomString();
                        var password = Helper.Encrypt(file.password, key);
                        sql += "INSERT INTO File (pid, url,filesize,title,name,new_name,password,password_key) " +
                                    "values ('" + pid + "','" + file.url + "','" + file.filesize + "','" + file.title + "','" + file.name + "','" + file.new_name + ".bin','" + password + "','" + key + "');";
                    }
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    index++;
                }

                foreach (var product in myProducts.college)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(product.picture))
                        local_picture = Helper.saveImage(product.picture);

                    var sql = "INSERT INTO Product (id,nid, title,author,picture,local_picture,order_time,price,type) " +
                                    "values ('" + index + "','" + product.nid + "','" + product.title + "','" + product.author + "','" + product.picture + "','" + local_picture + "','" + product.order_time + "'," + product.price + ",'college')";
                    SQLiteCommand commandp = new SQLiteCommand(sql, m_dbConnection);
                    commandp.Dispose();

                    var pid = index;
                    sql = string.Empty;
                    foreach (var file in product.files)
                    {
                        var key = Helper.RandomString();
                        var password = Helper.Encrypt(file.password, key);
                        sql += "INSERT INTO File (pid, url,filesize,title,name,new_name,password,password_key) " +
                                    "values ('" + pid + "','" + file.url + "','" + file.filesize + "','" + file.title + "','" + file.name + "','" + file.new_name + ".bin','" + password + "','" + key + "');";
                    }
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    index++;
                }

                foreach (var product in myProducts.product_kit)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(product.picture))
                        local_picture = Helper.saveImage(product.picture);

                    var sql = "INSERT INTO Product (id,nid, title,author,picture,local_picture,order_time,price,type) " +
                                    "values ('" + index + "','" + product.nid + "','" + product.title + "','" + product.author + "','" + product.picture + "','" + local_picture + "','" + product.order_time + "'," + product.price + ",'product_kit')";
                    SQLiteCommand commandp = new SQLiteCommand(sql, m_dbConnection);
                    commandp.Dispose();

                    var pid = index;
                    sql = string.Empty;
                    foreach (var file in product.files)
                    {
                        var key = Helper.RandomString();
                        var password = Helper.Encrypt(file.password, key);
                        sql += "INSERT INTO File (pid, url,filesize,title,name,new_name,password,password_key) " +
                                    "values ('" + pid + "','" + file.url + "','" + file.filesize + "','" + file.title + "','" + file.name + "','" + file.new_name + ".bin','" + password + "','" + key + "');";

                    }
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    index++;
                }

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public MyProduct getMyProduct()
        {
            MyProduct myProductObj = null;
            try
            {
                DataTable myProduct = new DataTable();
                var sql = "SELECT * FROM Product";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                myProduct.Load(command.ExecuteReader());
                command.Dispose();
                myProductObj = new MyProduct();

                for (int i = 0; i < myProduct.Rows.Count; i++)
                {
                    var productObj = new Product();
                    var type = myProduct.Rows[i]["type"].ToString();

                    #region load Files

                    DataTable files = new DataTable();
                    var id = myProduct.Rows[i]["id"].ToString();
                    sql = "SELECT * FROM File WHERE pid = " + id;
                    command = new SQLiteCommand(sql, m_dbConnection);
                    files.Load(command.ExecuteReader());

                    #endregion

                    productObj.author = myProduct.Rows[i]["author"].ToString();
                    productObj.nid = int.Parse(myProduct.Rows[i]["nid"].ToString());
                    productObj.order_time = int.Parse(myProduct.Rows[i]["order_time"].ToString());
                    productObj.picture = myProduct.Rows[i]["picture"].ToString();
                    productObj.local_picture = myProduct.Rows[i]["local_picture"].ToString();
                    productObj.price = int.Parse(myProduct.Rows[i]["price"].ToString());
                    productObj.title = myProduct.Rows[i]["title"].ToString();
                    productObj.files = new List<File>();
                    for (int j = 0; j < files.Rows.Count; j++)
                    {
                        var fileObj = new File();
                        fileObj.title = files.Rows[j]["title"].ToString();
                        fileObj.url = files.Rows[j]["url"].ToString();
                        fileObj.filesize = int.Parse(files.Rows[j]["filesize"].ToString());
                        fileObj.name = files.Rows[j]["name"].ToString();
                        fileObj.new_name = files.Rows[j]["new_name"].ToString();
                        var key = files.Rows[j]["password_key"].ToString();
                        var password = files.Rows[j]["password"].ToString();
                        fileObj.password = Helper.Decrypt(password, key);
                        productObj.files.Add(fileObj);
                    }

                    if (type == "product_kit")
                    {
                        if (myProductObj.product_kit == null)
                            myProductObj.product_kit = new List<Product>();
                        myProductObj.product_kit.Add(productObj);
                    }
                    else if (type == "product")
                    {
                        if (myProductObj.product == null)
                            myProductObj.product = new List<Product>();
                        myProductObj.product.Add(productObj);
                    }
                    else
                    {
                        if (myProductObj.college == null)
                            myProductObj.college = new List<Product>();
                        myProductObj.college.Add(productObj);
                    }
                }
                return myProductObj;
            }
            catch (Exception e)
            {
                return myProductObj;
            }
        }
        public bool deleteMyProduct()
        {
            try
            {
                deleteMyProductFils();
                var sql = "DELETE FROM Product";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool deleteMyProductFils()
        {
            try
            {
                var sql = "DELETE FROM File";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion


        #region User

        public bool insertUser(User model)
        {
            try
            {
                deleteUser();
                string local_picture = null;
                if (!string.IsNullOrEmpty(model.picture))
                    local_picture = Helper.saveImage(model.picture);

                var isPrivateMsg = model.privatemsg_disabled ? "1" : "0";
                var sql = "INSERT INTO User (uid, name,mail,created,login,picture,local_picture,privatemsg_disabled,password) " +
                                    "values ('" + model.uid + "','" + model.name + "','" + model.mail + "','" + model.created + "','" + model.login + "','" + model.picture + "','" + local_picture + "'," + isPrivateMsg + ",'" + model.password + "')";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public User getUser()
        {
            User user = null;
            try
            {
                var sql = "SELECT * FROM User";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    user = new User();
                    user.uid = Convert.ToInt32(rdr["uid"]);
                    user.privatemsg_disabled = Convert.ToBoolean(rdr["privatemsg_disabled"]);
                    user.picture = rdr["picture"].ToString();
                    user.local_picture = rdr["local_picture"].ToString();
                    user.name = rdr["name"].ToString();
                    user.mail = rdr["mail"].ToString();
                    user.login = rdr["login"].ToString();
                    user.created = rdr["created"].ToString();
                    user.password = rdr["password"].ToString();
                }
                return user;
            }
            catch (Exception e)
            {
                return user;
            }
        }
        public bool deleteUser()
        {
            try
            {
                var sql = "DELETE FROM User";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion


        #region Profile

        public bool insertProfile(Profile model)
        {
            try
            {
                deleteProfile();
                string local_picture = null;
                if (!string.IsNullOrEmpty(model.background_image))
                    local_picture = Helper.saveImage(model.background_image);

                var sql = "INSERT INTO Profile (pid, full_name,about_me,skills,university,education_field,education_degree,mobile,job,user_point,background_image,background_local_image) " +
                                    "values ('" + model.pid + "','" + model.full_name + "','" + model.about_me + "','" + model.skills + "','" + model.university + "','" + model.education_field + "','" + model.education_degree + "','" + model.mobile + "','" + model.job + "','" + model.user_point + "','" + model.background_image + "','" + local_picture + "')";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool deleteProfile()
        {
            try
            {
                var sql = "DELETE FROM Profile";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Profile getProfile()
        {
            Profile profile = null;
            try
            {
                var sql = "SELECT * FROM Profile";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    profile = new Profile();
                    profile.about_me = rdr["about_me"].ToString();
                    profile.background_image = rdr["background_image"].ToString();
                    profile.background_local_image = rdr["background_local_image"].ToString();
                    profile.education_degree = rdr["education_degree"].ToString();
                    profile.education_field = rdr["education_field"].ToString();
                    profile.full_name = rdr["full_name"].ToString();
                    profile.job = rdr["job"].ToString();
                    profile.mobile = rdr["mobile"].ToString();
                    profile.pid = int.Parse(rdr["pid"].ToString());
                    profile.skills = rdr["skills"].ToString();
                    profile.university = rdr["university"].ToString();
                    profile.user_point = rdr["user_point"].ToString();
                }
                return profile;
            }
            catch (Exception e)
            {
                return profile;
            }
        }

        #endregion


        #region LastContent

        public bool insertLastContent(LastContent lastContents)
        {
            try
            {
                deleteLastContent();
                var sql = string.Empty;
                foreach (var product in lastContents.product)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(product.picture))
                        local_picture = Helper.saveImage(product.picture);

                    sql += "INSERT INTO LastContent (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + product.nid + "','" + product.title + "','" + product.url + "','" + product.picture + "','" + local_picture + "','product');";
                }

                foreach (var college in lastContents.college)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(college.picture))
                        local_picture = Helper.saveImage(college.picture);

                    sql += "INSERT INTO LastContent (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + college.nid + "','" + college.title + "','" + college.url + "','" + college.picture + "','" + local_picture + "','college');";

                }

                foreach (var product_kit in lastContents.product_kit)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(product_kit.picture))
                        local_picture = Helper.saveImage(product_kit.picture);

                    sql += "INSERT INTO LastContent (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + product_kit.nid + "','" + product_kit.title + "','" + product_kit.url + "','" + product_kit.picture + "','" + local_picture + "','product_kit');";

                }
                SQLiteCommand commandp = new SQLiteCommand(sql, m_dbConnection);
                commandp.ExecuteNonQuery();
                commandp.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public LastContent getLastContent()
        {
            LastContent lastContentObj = null;
            try
            {
                DataTable lastContents = new DataTable();
                var sql = "SELECT * FROM LastContent";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                lastContents.Load(command.ExecuteReader());
                command.Dispose();
                lastContentObj = new LastContent();

                for (int i = 0; i < lastContents.Rows.Count; i++)
                {
                    var productObj = new Pedia();
                    var type = lastContents.Rows[i]["type"].ToString();

                    productObj.nid = int.Parse(lastContents.Rows[i]["nid"].ToString());
                    productObj.picture = lastContents.Rows[i]["picture"].ToString();
                    productObj.local_picture = lastContents.Rows[i]["local_picture"].ToString();
                    productObj.title = lastContents.Rows[i]["title"].ToString();
                    productObj.url = lastContents.Rows[i]["url"].ToString();


                    if (type == "product_kit")
                    {
                        if (lastContentObj.product_kit == null)
                            lastContentObj.product_kit = new List<Pedia>();
                        lastContentObj.product_kit.Add(productObj);
                    }
                    else if (type == "product")
                    {
                        if (lastContentObj.product == null)
                            lastContentObj.product = new List<Pedia>();
                        lastContentObj.product.Add(productObj);
                    }
                    else
                    {
                        if (lastContentObj.college == null)
                            lastContentObj.college = new List<Pedia>();
                        lastContentObj.college.Add(productObj);
                    }
                }
                return lastContentObj;
            }
            catch (Exception e)
            {
                return lastContentObj;
            }
        }
        public bool deleteLastContent()
        {
            try
            {
                var sql = "DELETE FROM LastContent";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion



        #region Suggestion

        public bool insertSuggestion(LastContent lastContents)
        {
            try
            {
                deleteSuggestion();
                var sql = string.Empty;
                foreach (var product in lastContents.product)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(product.picture))
                        local_picture = Helper.saveImage(product.picture);

                    sql += "INSERT INTO Suggestion (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + product.nid + "','" + product.title + "','" + product.url + "','" + product.picture + "','" + local_picture + "','product');";
                }

                foreach (var college in lastContents.college)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(college.picture))
                        local_picture = Helper.saveImage(college.picture);

                    sql += "INSERT INTO Suggestion (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + college.nid + "','" + college.title + "','" + college.url + "','" + college.picture + "','" + local_picture + "','college');";
                }

                foreach (var product_kit in lastContents.product_kit)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(product_kit.picture))
                        local_picture = Helper.saveImage(product_kit.picture);

                    sql += "INSERT INTO Suggestion (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + product_kit.nid + "','" + product_kit.title + "','" + product_kit.url + "','" + product_kit.picture + "','" + local_picture + "','product_kit');";
                }
                SQLiteCommand commandp = new SQLiteCommand(sql, m_dbConnection);
                commandp.ExecuteNonQuery();
                commandp.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public LastContent getSuggestion()
        {
            LastContent lastContentObj = null;
            try
            {
                DataTable lastContents = new DataTable();
                var sql = "SELECT * FROM Suggestion";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                lastContents.Load(command.ExecuteReader());
                command.Dispose();
                lastContentObj = new LastContent();

                for (int i = 0; i < lastContents.Rows.Count; i++)
                {
                    var productObj = new Pedia();
                    var type = lastContents.Rows[i]["type"].ToString();

                    productObj.nid = int.Parse(lastContents.Rows[i]["nid"].ToString());
                    productObj.picture = lastContents.Rows[i]["picture"].ToString();
                    productObj.local_picture = lastContents.Rows[i]["local_picture"].ToString();
                    productObj.title = lastContents.Rows[i]["title"].ToString();
                    productObj.url = lastContents.Rows[i]["url"].ToString();


                    if (type == "product_kit")
                    {
                        if (lastContentObj.product_kit == null)
                            lastContentObj.product_kit = new List<Pedia>();
                        lastContentObj.product_kit.Add(productObj);
                    }
                    else if (type == "product")
                    {
                        if (lastContentObj.product == null)
                            lastContentObj.product = new List<Pedia>();
                        lastContentObj.product.Add(productObj);
                    }
                    else
                    {
                        if (lastContentObj.college == null)
                            lastContentObj.college = new List<Pedia>();
                        lastContentObj.college.Add(productObj);
                    }
                }
                return lastContentObj;
            }
            catch (Exception e)
            {
                return lastContentObj;
            }
        }
        public bool deleteSuggestion()
        {
            try
            {
                var sql = "DELETE FROM Suggestion";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion


        #region Bookmark

        public bool insertBookmark(Bookmark bookmark)
        {
            try
            {
                deleteBookmark();
                var sql = string.Empty;
                foreach (var item in bookmark.article)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','article');";
                }
                foreach (var item in bookmark.blog)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','blog');";
                }
                foreach (var item in bookmark.college)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','college');";
                }
                foreach (var item in bookmark.designteam)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','designteam');";
                }
                foreach (var item in bookmark.education)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','education');";
                }
                foreach (var item in bookmark.film)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','film');";
                }
                foreach (var item in bookmark.gallerynew)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','gallerynew');";
                }
                foreach (var item in bookmark.pedia)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','pedia');";
                }
                foreach (var item in bookmark.podcast)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','podcast');";
                }
                foreach (var item in bookmark.product)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','product');";
                }
                foreach (var item in bookmark.product_kit)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','product_kit');";
                }
                foreach (var item in bookmark.publication)
                {
                    string local_picture = null;
                    if (!string.IsNullOrEmpty(item.picture))
                        local_picture = Helper.saveImage(item.picture);

                    sql += "INSERT INTO Bookmark (nid, title,url,picture,local_picture,type) " +
                                    "values ('" + item.nid + "','" + item.title + "','" + item.url + "','" + item.picture + "','" + local_picture + "','publication');";
                }
                SQLiteCommand commandp = new SQLiteCommand(sql, m_dbConnection);
                commandp.ExecuteNonQuery();
                commandp.Dispose();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Bookmark getBookmark()
        {
            Bookmark bookmarks = null;
            try
            {
                DataTable lastContents = new DataTable();
                var sql = "SELECT * FROM Bookmark";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                lastContents.Load(command.ExecuteReader());
                command.Dispose();
                bookmarks = new Bookmark();

                for (int i = 0; i < lastContents.Rows.Count; i++)
                {
                    var pediaObj = new Pedia();
                    var type = lastContents.Rows[i]["type"].ToString();

                    pediaObj.nid = int.Parse(lastContents.Rows[i]["nid"].ToString());
                    pediaObj.picture = lastContents.Rows[i]["picture"].ToString();
                    pediaObj.local_picture = lastContents.Rows[i]["local_picture"].ToString();
                    pediaObj.title = lastContents.Rows[i]["title"].ToString();
                    pediaObj.url = lastContents.Rows[i]["url"].ToString();

                    switch (type)
                    {
                        case "article":
                            if (bookmarks.article == null)
                                bookmarks.article = new List<Pedia>();
                            bookmarks.article.Add(pediaObj);
                            break;
                        case "blog":
                            if (bookmarks.blog == null)
                                bookmarks.blog = new List<Pedia>();
                            bookmarks.blog.Add(pediaObj);
                            break;
                        case "college":
                            if (bookmarks.college == null)
                                bookmarks.college = new List<Pedia>();
                            bookmarks.college.Add(pediaObj);
                            break;
                        case "designteam":
                            if (bookmarks.designteam == null)
                                bookmarks.designteam = new List<Pedia>();
                            bookmarks.designteam.Add(pediaObj);
                            break;
                        case "education":
                            if (bookmarks.education == null)
                                bookmarks.education = new List<Pedia>();
                            bookmarks.education.Add(pediaObj);
                            break;
                        case "film":
                            if (bookmarks.film == null)
                                bookmarks.film = new List<Pedia>();
                            bookmarks.film.Add(pediaObj);
                            break;
                        case "gallerynew":
                            if (bookmarks.gallerynew == null)
                                bookmarks.gallerynew = new List<Pedia>();
                            bookmarks.gallerynew.Add(pediaObj);
                            break;
                        case "pedia":
                            if (bookmarks.pedia == null)
                                bookmarks.pedia = new List<Pedia>();
                            bookmarks.pedia.Add(pediaObj);
                            break;
                        case "podcast":
                            if (bookmarks.podcast == null)
                                bookmarks.podcast = new List<Pedia>();
                            bookmarks.podcast.Add(pediaObj);
                            break;
                        case "product":
                            if (bookmarks.product == null)
                                bookmarks.product = new List<Pedia>();
                            bookmarks.product.Add(pediaObj);
                            break;
                        case "product_kit":
                            if (bookmarks.product_kit == null)
                                bookmarks.product_kit = new List<Pedia>();
                            bookmarks.product_kit.Add(pediaObj);
                            break;
                        case "publication":
                            if (bookmarks.publication == null)
                                bookmarks.publication = new List<Pedia>();
                            bookmarks.publication.Add(pediaObj);
                            break;
                    }
                }
                return bookmarks;
            }
            catch (Exception e)
            {
                return bookmarks;
            }
        }
        public bool deleteBookmark()
        {
            try
            {
                var sql = "DELETE FROM Bookmark";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

    }
}
