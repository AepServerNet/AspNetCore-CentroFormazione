using System.Collections.Generic;

namespace App.Models.Validators
{
    public interface IRemotePropertyValidator
    {
        string Url { get; }
        string ErrorText { get; }
        IEnumerable<string> AdditionalFields { get; }
    }
}