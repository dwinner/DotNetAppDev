// Copyright (C) 2011 Oliver Sturm <oliver@oliversturm.com>
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 3 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, see <http://www.gnu.org/licenses/>.
  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FCSlib;
using System.Diagnostics;

namespace chapter8 {
  public static class Calculator {
    public static int Add(int x, int y) {
      return x + y;
    }

    public static readonly Func<int, Func<int, int>> AddC =
      Functional.Curry<int, int, int>(Add);

    public static int Mult(int x, int y) {
      return x * y;
    }

    public static readonly Func<int, Func<int, int>> MultC =
      Functional.Curry<int, int, int>(Mult);
  }
}
