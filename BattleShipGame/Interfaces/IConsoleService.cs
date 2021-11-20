namespace BattleShipGame.Services
{
    public interface IConsoleService
    {
        void WriteLine(string s);
        string ReadLine();
        int ReadInteger();
        string ReadString();
    }
}