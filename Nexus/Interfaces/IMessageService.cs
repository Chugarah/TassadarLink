namespace Nexus.Interfaces;

public interface IMessageService
{
    void DisplayMessage(string route, string message);
    void ClearMessage();
    void DisplayErrorMessage(string message);
    void DisplaySuccessMessage(string message);
    void SetMenuEndLine();
}