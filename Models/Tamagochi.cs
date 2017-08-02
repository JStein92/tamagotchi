using System.Collections.Generic;
using System;

namespace TamagochiMaker.Models
{
  public class Tamagochi
  {
    private string _name;
    private int _hunger;
    private int _attention;
    private int _rest;
    private static List<Tamagochi> _myTamagochis = new List<Tamagochi>() {};
    private int _id;
    private bool _isAlive;

    public Tamagochi(string name, int hunger = 100, int attention = 100, int rest = 100)
    {
      _name = name;
      _hunger = hunger;
      _attention = attention;
      _rest = rest;
      _isAlive = true;
      _myTamagochis.Add(this);
      _id = _myTamagochis.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string name)
    {
      _name = name;
    }
    public int GetHunger()
    {
      return _hunger;
    }
    public void SetHunger(int hunger)
    {
      _hunger = hunger;
    }
    public int GetAttention() {
      return _attention;
    }
    public void SetAttention(int attention)
    {
      _attention = attention;
    }
    public int GetRest()
    {
      return _rest;
    }
    public void SetRest(int rest)
    {
      _rest = rest;
    }

    public static List<Tamagochi> GetAll()
    {
      return _myTamagochis;
    }
    public int GetId()
    {
      return _id;
    }
    public static Tamagochi Find(int index)
    {
      return _myTamagochis[index - 1];
    }

    public void Kill()
    {
      _isAlive = false;
    }

    public bool IsAlive()
    {
      return _isAlive;
    }

    public int ValueCapped(int value)
    {
      if(value >= 100)
      {
        value = 100;
      }
      return value;
    }

    public void Attention()
    {
      PassTime();
      _attention += 20;
      _attention = ValueCapped(_attention);
    }

    public void Rest()
    {
      PassTime();
      _rest += 20;
      _rest = ValueCapped(_rest);
    }

    public void Feed()
    {
      PassTime();
      Console.WriteLine("I WAS JUST FED");
      _hunger += 20;
      _hunger = ValueCapped(_hunger);
    }

    public void PassTime()
    {
      foreach(var t in _myTamagochis)
      {
        t.SetHunger(t.GetHunger()-5);
        t.SetAttention(t.GetAttention()-5);
        t.SetRest(t.GetRest()-5);

        if (t.GetHunger() <=0 || t.GetAttention() <=0 || t.GetRest()<=0 ) {
          t.Kill();
          Console.WriteLine(t.GetName() + " has died of dysentary");
        }
      }
    }
  }
}
