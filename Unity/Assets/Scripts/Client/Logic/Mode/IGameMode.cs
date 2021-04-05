using Cysharp.Threading.Tasks;

public interface IGameMode
{
    UniTask Enter();
    UniTask Exit();
}