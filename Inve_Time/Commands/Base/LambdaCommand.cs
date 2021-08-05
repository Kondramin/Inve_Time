using System;

namespace Inve_Time.Commands.Base
{
    /// <summary>Realise lambda sample to commands</summary>
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public LambdaCommand(Action Execute, Func<bool> CanExecute = null)
            : this(p => Execute(), CanExecute is null ? (Func<object, bool>)null : p => CanExecute())
        {

        }

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object p) => _CanExecute?.Invoke(p) ?? true;

        public override void Execute(object p) => _Execute(p);
    }
}
