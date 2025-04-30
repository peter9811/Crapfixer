using System.Threading.Tasks;

namespace Crapfixer
{
    public abstract class FeatureBase
    {
        public abstract string ID();
        public abstract string Info();
        public abstract string GetFeatureDetails();
        public abstract bool CheckFeature();
        public abstract Task<bool> DoFeature();  // async
        public abstract bool UndoFeature();
    }

}
