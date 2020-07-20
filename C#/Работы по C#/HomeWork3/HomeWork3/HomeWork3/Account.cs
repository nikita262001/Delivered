using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{
    public class Account : IAccount
    {
        // Событие возникающее при добавление Человека
        protected internal event AccountStateHandler SkipWork;
        // Событие возникающее при снятии денег
        protected internal event AccountStateHandler WithdrawSum;

        protected int _id;
        static int counter = 0;

        protected int _age;
        protected string _name;
        protected string _surname;
        public decimal _sum; //заработал в компаниях

        public Account(int age,string name,string surname)
        {
            _age = age;
            _name = name;
            _surname = surname;
            _id = counter++;
        }

        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if (handler != null && e != null)
                handler(this, e);
        }
        protected void OnOpened(AccountEventArgs e)
        {
            CallEvent(e, SkipWork);
        }
        protected virtual void OnAdded(AccountEventArgs e)
        {
            CallEvent(e, WithdrawSum);
        }
        protected virtual void OnWithdrawed(AccountEventArgs e)
        {
            CallEvent(e, WithdrawSum);
        }

        //
        protected internal void CreatePers()
        {
            OnOpened(new AccountEventArgs("Создан новый человек! Id человека: " + this._id, this._sum));
        }
        public virtual void SkipWorkDays(decimal sum)
        {
            _sum += sum;
            OnAdded(new AccountEventArgs("На счет поступило " + sum, sum));
        }

        public virtual void Put(decimal sum)
        {
            _sum += sum;
            OnAdded(new AccountEventArgs("На счет поступило " + sum, sum));
        }
        public virtual decimal Withdraw(decimal sum)
        {
            decimal result = 0;
            if (sum <= _sum)
            {
                _sum -= sum;
                result = sum;
                OnWithdrawed(new AccountEventArgs("Сумма " + sum + " снята со счета " + _id, sum));
            }
            else
            {
                OnWithdrawed(new AccountEventArgs("Недостаточно денег на счете " + _id, 0));
            }
            return result;
        }

        public decimal CurrentSum
        {
            get { return _sum; }
        }

        public int Id
        {
            get { return _id; }
        }
    }
}
