namespace UniHelper.Backend.Services.Interfaces;

/// <summary>
/// Common Service
/// </summary>
public interface ICommonService
{
    /// <summary>
    /// Get logged user's Id
    /// </summary>
    /// <returns>Id</returns>
    int GetLoggedUserId();
}
