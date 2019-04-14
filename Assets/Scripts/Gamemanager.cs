using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    [SerializeField]
    List<Client> clients;
    [SerializeField]
    List<Table> tables;

    List<string> orders;

    public List<string> Orders { get => orders; set => orders = value; }

    private void Awake()
    {
        instance = this;
        orders = new List<string>();
    }

    public Table selectTable()
    {
        Table t = new Table();
        foreach (Table table in tables)
        {
            if(table.HasClient && !table.IsEating)
            {
                t = table;
                break;
            }
        }
        return t;
    }
}
