using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Contecxt context = new Contecxt();
            ModifiedState modified = new ModifiedState();
            modified.DoAction(context);
            DeleteState deleted = new DeleteState();
            deleted.DoAction(context);

            Console.WriteLine(context.GetState().ToString());

            Console.ReadLine();
        }
    }
    interface IState
    {
        void DoAction(Contecxt context);
    }
    class ModifiedState : IState
    {
        public void DoAction(Contecxt context)
        {
            Console.WriteLine("Satate : Modified");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Modified";
        }
    }
    class DeleteState : IState
    {
        public void DoAction(Contecxt context)
        {
            Console.WriteLine("State : Deleted");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }
    class AddedState : IState
    {
        public void DoAction(Contecxt context)
        {
            Console.WriteLine("State : Added");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Added";
        }
    }
    class Contecxt
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }
        public IState GetState()
        {
            return _state;
        }
    }
}
