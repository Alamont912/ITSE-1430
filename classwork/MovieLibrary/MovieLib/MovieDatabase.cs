using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public class MovieDatabase
    {
        public MovieDatabase() : this("My Movies")  //constructor-chaining (call this but the version with the parameter)
        {
            //Do minimal initialization of instance (if any), nothing complicated!!
            //Don't initialize fields in here, that's what field initializers are for.
            //If the field depends on other's order or data after initialization, put it in here.
        }
        public MovieDatabase(string name) //: this()  //constructor-chaining (call this but with no params, aka default constructor)
        {
            Name = name;
        }
        //private string _name;

        public string Name { get; set; }

        public virtual void Add ( Movie movie )
        {

        }   //virtual only applies to inheritance.
                                                    //provides a default implementation, but
                                                    //derived types can alter it.
        public void Delete ( Movie movie )
        {

        }

        public void Update (Movie movie)
        {

        }

        public Movie Find(string name)
        {
            return null;
        }

        public Movie Get ()
        {
            return null;
        }

        protected void Foo () { }   //protected only needed for inheritance.
                                    //means accessable to this type and derived types
                                    //but private to everything else.
    }

}
