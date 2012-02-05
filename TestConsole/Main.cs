/*
Copyright (C) 2012 Yoshikazu Miyoshi <yoshikazum@gmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using System.Net;

namespace TestConsole
{
  class MainClass
  {
    public static void DoWebRequest ()
    {
     
      HttpWebRequest httpWebRequest = 
       (System.Net.HttpWebRequest)HttpWebRequest.Create ("http://www.google.com/");
     
      HttpWebResponse httpWebResponse = 
       (System.Net.HttpWebResponse)httpWebRequest.GetResponse ();
     
      System.IO.Stream stream = httpWebResponse.GetResponseStream ();
      System.IO.StreamReader streamReader = new System.IO.StreamReader (stream);
     
      string response = streamReader.ReadToEnd ();
     
      Console.Write (response);
      Console.WriteLine ();
    }
   
    public static void DoSamleRamda ()
    {
      Action<string> action = 
       (text) => Console.WriteLine (text);
     
      action ("hoge");
      action ("sample");
    }

    public static void QuestionOperator ()
    {
      string name = null;

      Console.WriteLine (name ?? "hogehoge");
    }

    delegate void TestDelegate(string nameString);

    public static void DoSampleDelegate(){
      TestDelegate testDelegate = (nameString) => {
        Console.WriteLine(nameString);
      };
      testDelegate("DoSampleDelegate");

      Action<string> action = (name)=>{
        Console.WriteLine(name);
      };
      DoSampleDelegate2(action);

    }

    public static void DoSampleDelegate2(Action<string> testDelegate){
      testDelegate("DoSampleDelegate2");
    }

    public static void DoSampleRamda(){
      SampleRamda ramda = new SampleRamda();
      ramda.Phase1(()=>{
        Console.WriteLine("1:Phase1");
      });

      bool result = ramda.Phase2(()=>{
        Console.WriteLine("1:Phase2");
        return "hoge";
      });

      Console.WriteLine("1:result: {0}", result);
    }

    public static void DoSampleRamda2(){
      SampleRamda ramda = new SampleRamda();
      ramda.Phase1(()=>{
        Console.WriteLine("2:Phase1");
      });
      bool result = ramda.Phase2(()=>{
        Console.WriteLine("2:Phase2");
        return "fuga";
      });

      Console.WriteLine("2:result: {0}", result);
    }

    public static void Main (string[] args)
    {
      Console.WriteLine ("Hello World!");

      //MainClass.DoWebRequest ();
      //MainClass.DoSamleRamda ();
      QuestionOperator();
      DoSampleDelegate();
      DoSampleRamda();
      DoSampleRamda2();
    }
  }

  delegate string Input();
  class SampleRamda{
    internal void Phase1(Action action){
      action();
    }
    internal bool Phase2(Input input){
      string name = input();
      return name == "hoge";
    }
  }
}
