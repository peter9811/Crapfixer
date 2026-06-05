using System.Threading.Tasks;

namespace CrapFixer
{
    public abstract class FeatureBase
    {
        public abstract string ID();
        public abstract string Info();
        public abstract string GetFeatureDetails();
        public abstract Task<bool> CheckFeature();
        public abstract Task<bool> DoFeature();
        public abstract Task<bool> UndoFeature();
    }
}
