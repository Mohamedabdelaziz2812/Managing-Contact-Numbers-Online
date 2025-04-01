using System.Text.RegularExpressions;

namespace Contellect_Task._Shared;

public class Globals
{
    private readonly IConfiguration _configurations;
    public Globals(IConfiguration configurations)
    {
        _configurations = configurations;
    }

    public string ReportsFolderPath { get; set; }
    public string ReportLicenseKey { get; set; }


    public enum StringLength
    {
        LabelLength = 20,
        phoneLength = 15,
        GUID = 50,
        CommentLength = 1000,
        ShortName = 120,
        Title = 200,
        LongName = 500,
        AddressLength = 1000,
        ImageLength = 200,
        VideoLength = 200,
        HashLength = 512,
        EmailLength = 100,
        FileLength = 200,
        ImageFileLength = 2000000,
        DescriptionLength = 5000,
        UploadFileLength = 30000000,
        NameLength = 30000001,
        DefaultImageWidth = 1920,
        DefaultImageHeight = 1080,
    }



    public static Dictionary<string, string> RegEx = new Dictionary<string, string>
    {
        //{ "Name", @"^[A-Za-z ءأ-ي]*$" },
        { "Name",        @"^\S([أ-يءA-Za-z0-9-_]{1,50}( [أ-يءA-Za-z0-9-_]{1,50})*) ?$" },
        { "Description", @"^\S([أ-يءA-Za-z0-9-_]{1,}( [أ-يءA-Za-z0-9-_]{1,})*) ?$" },
        { "Phone", @"^[0-9\u0660-\u0669]{9,14}$" },
        { "PhoneLandLine", @"^[0-9\u0660-\u0669]{5,14}$" },
        { "Id", @"^[1-9]+[0-9]*$" },
        { "Number",@"^\d{1,10}(\.\d{1,2})?$" },
        { "IntegerNumber",@"^[0-9\u0660-\u0669]*$" },
        { "Email", @"^[a-zA-Z0-9]{2,30}((\.|-)([a-zA-Z0-9]{2,30})){0,4}?@[a-zA-Z]{2,30}((\.|-)([a-zA-Z]{2,30})){1,4}?$" },
        { "URL", @"^(https:\/\/)?(http:\/\/)?(www\.)?[a-z]+\.([a-z]{2,10}\.)?[a-z]{2,3}(\.[a-z]{2,3})?([\/\w\+\?!&=%\-#]{1,})?$" },


    };

    public object CommandResponseMsg(string v)
    {
        throw new NotImplementedException();
    }

    public static Dictionary<string, string> RegExMsg = new Dictionary<string, string>
    {
        { "Name", "Must Not Exceed 50 Characters" },
        { "Phone", "Phone Must Be Numbers at Least 10 Numbers" },
        { "Number", @"Numbers Only" },
        { "Email", @"Email not valid, must be like xxx@xxxx.xxx" },

    };
    /// <summary>
    /// Message For Minmum Length and Max Length Errors
    /// </summary>
    /// <param name="Property"></param>
    /// <param name="Length">Number Of Length</param>
    /// <param name="LengthType">Maximum Or Minmum </param>
    /// <param name="PropertyType">Charcter Or Numbers</param>
    /// <returns></returns>

    /// <summary>
    /// Return Formated Date Time as yyyy-MM-dd hh:mm tt
    /// </summary>
    /// <param name="date"></param>
    /// <returns>yyyy-MM-dd hh:mm tt</returns>
    public static string FormatedDateTimeString(DateTime date)
    {
        return date.ToString("yyyy-MM-dd hh:mm tt");
    }


    ///// <summary>
    ///// Message For Ids For Not Empty Or 0
    ///// </summary>
    ///// <param name="EntityName"></param>
    ///// <returns></returns>
    //public static string IdsErrorMsg(string EntityName)
    //{
    //    return $"{EntityName} Id Must Be Not Empty and Greater Than 0.";
    //}
    /// <summary>
    /// Message For Ids For Not Empty Or 0
    /// </summary>
    /// <param name="EntityName"></param>

    /// <summary>
    /// Message For Required Property
    /// </summary>
    /// <param name="ProprtyName"></param>
    /// <returns></returns>

    /// <summary>
    /// Message For Required Property
    /// </summary>
    /// <param name="ProprtyName"></param>
    /// <returns></returns>




    /// <summary>
    /// function display msg for Delete failure exception
    /// </summary>
    /// <param name="entityName"></param>


    /// <summary>
    /// function display msg for Not Found exception
    /// </summary>
    /// <param name="entityName"></param>
    /// <param name="EntityId"></param>
    /// <returns></returns>


    /// <summary>
    /// For rollback and commit actions
    /// </summary>


    /// <summary>
    /// 
    /// </summary>
    /// <param name="action">Action that happen when exception occured like as Add or Update or Delete....</param>
    /// <param name="EntityName">Name of entity which is used</param>
    /// <param name="key">Key which is unique index in database like as Name or Id</param>
    /// <returns></returns>

    /// <summary>
    /// function that take key for regex and return error msg
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>

    /// <summary>
    /// Return with Msg for response
    /// </summary>
    /// <param name="EntityName">Like Branch, Company.....</param>
    /// <param name="Action">Action that occuer on api like (Added, Updated, Deleted, Changed)</param>
    /// <returns></returns>

    /// <summary>
    /// send Key Message and Get any Localized Messasge
    /// /// </summary>
    /// <param name="keyMsg"></param>
    /// <returns>Localized Msg </returns>


    public static string ShortGUID()
    {
        return Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
    }

    public static string GetRequestDomainName(string PathBase)
    {
        var PathBaseList = PathBase.Split(".").ToList();
        if (PathBaseList.Count <= 0)
            return string.Empty;
        PathBaseList.RemoveAt(0);

        string baseName = string.Join(".", PathBaseList);
        return baseName;
    }


}
