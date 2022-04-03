using System.Collections;

namespace Bootstrappers
{
    public interface ICoroutineRunner
    {
        void RunCoroutine(IEnumerator coroutine);
    }
}