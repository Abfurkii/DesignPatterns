using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDesign
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifiedState modified = new ModifiedState();
            modified.DoAction(context);

            Console.WriteLine(context.GetContext().ToString());

            DeletedState deleted = new DeletedState();
            deleted.DoAction(context);

            Console.WriteLine(context.GetContext().ToString());

            Console.ReadLine();
        }
    }
    public interface IState
    {
        void DoAction(Context context);
    }
    public class ModifiedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Modified");
            context.SetContext(this);
        }
        public override string ToString()
        {
            return "Modified";
        }
    }
    public class DeletedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            context.SetContext(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }
    public class AddedState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("State : Added");
            context.SetContext(this);
        }
        public override string ToString()
        {
            return "Added";
        }
    }
    public class Context
    {
        private IState _state;
        public void SetContext(IState state)
        {
            _state = state;
        }
        public IState GetContext()
        {
            return _state;
        }
    }
}
