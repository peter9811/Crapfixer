using System.Threading.Tasks;

namespace CrapFixer
{
    public abstract class FeatureBase
    {
        /// <summary>
        /// Gets the unique identifier for this feature.
        /// </summary>
        /// <returns>A string representing the unique ID of the feature.</returns>
        public abstract string ID();

        /// <summary>
        /// Gets a brief informational string about the feature.
        /// This is typically a short description or title.
        /// </summary>
        /// <returns>A string containing brief information about the feature.</returns>
        public abstract string Info();

        /// <summary>
        /// Gets detailed information or a description of what the feature does.
        /// This can include explanations of its effects, benefits, or risks.
        /// </summary>
        /// <returns>A string containing detailed information about the feature.</returns>
        public abstract string GetFeatureDetails();

        /// <summary>
        /// Asynchronously checks the current status or state related to the feature.
        /// This method should determine if the feature's action needs to be applied,
        /// is already applied, or if it's not applicable.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean: <c>true</c> if the feature's condition is met
        /// (e.g., if a setting is active or a problem is detected), <c>false</c> otherwise.
        /// </returns>
        public abstract Task<bool> CheckFeature();  // async

        /// <summary>
        /// Asynchronously performs the primary action of the feature.
        /// This method applies the change, fix, or optimization the feature is designed for.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a boolean: <c>true</c> if the feature's action was
        /// successfully applied, <c>false</c> otherwise (e.g., if an error occurred or
        /// the action was not needed).
        /// </returns>
        public abstract Task<bool> DoFeature();    // async

        /// <summary>
        /// Reverts or undoes the action performed by the DoFeature method.
        /// This method should restore the system to the state it was in before the
        /// feature was applied, if possible.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the feature's action was successfully undone or reverted,
        /// <c>false</c> otherwise (e.g., if an error occurred or undo is not supported/possible).
        /// </returns>
        public abstract bool UndoFeature();
    }

}
