﻿/*
 * Copyright 2010 Chaur Wu.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;

namespace Aop
{
    public class Customer : IDynamicMetaObjectProvider
    {
        private int age;
        private String name;

        public Customer(String name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int Age 
        { 
            get 
            {
                Console.WriteLine("Customer Age getter is called."); 
                return age; 
            }
        }

        public String Name
        {
            get
            {
                Console.WriteLine("Customer Name getter is called.");
                return name;
            }
        }

        #region IDynamicMetaObjectProvider Members

        public DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter)
        {
            return new AopMetaObject(parameter, this);
        }

        #endregion
    }
}
