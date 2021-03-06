﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land_ : MonoBehaviour
{
    public List<House_> data;
    const float cost_rate=3.0f;
    const float profit_rate=0.1f;
    public float tmp_delta_explode_rate=0.0f;
    // Start is called before the first frame update
    Transform tf;
    void Start()
    {
        data=new List<House_>();
        tf=GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        update_house_pos();
    }
    public float get_risk()
    {
        float ret=0.0f;
        for(int u=0;u!=data.Count;++u)
        {
            ret+=data[u].risk;
        }
        return ret+tmp_delta_explode_rate;
    }
    public void add_house(House_ house)
    {
        data.Add(house);
    }
    public float explode()
    {
        float ret=0.0f;
        for(int u=0;u!=data.Count;++u)
            ret+=(data[u].price*cost_rate);
        clear_house();
        return ret;
    }
    public DeltaMoney_[] gain_profit()
    {
        DeltaMoney_[] ret=new DeltaMoney_[data.Count];
        for(int u=0;u!=data.Count;++u)
        {
            ret[u].owner_id=data[u].owner_id;
            ret[u].amount=data[u].price*profit_rate;
        }
        return ret;
    }
    void clear_house()
    {
        data.Clear();
    }
    void update_house_pos()
    {
        Vector3 local_pos=tf.position;
        for(int u=0;u!=data.Count;++u)
        {
            data[u].transform.position=local_pos+(new Vector3(0.0f,0.5f+data[u].get_spirite_height(),-0.5f+(u+1)/(data.Count)));
        }
    }
}
