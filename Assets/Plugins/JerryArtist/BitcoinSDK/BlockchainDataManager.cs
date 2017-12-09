﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using MiniJSON;
using SimpleJSON;

public class BlockchainDataManager
{

    private static int debugLevel = 1;

    public class Transaction
    {
        public int ver = 0; // 1
        // inputs
        public int weight = 0; // 1028
        public string relayed_by = ""; // "0.0.0.0"
        // out 
        public double lock_time = 0; // 498171
        public int size = 0; // 257
        public bool rbf = true;
        public bool double_spend = false;
        public double time = 0; // 1512701214
        public double tx_index = 0; // 309671994
        public int vin_sz = 0; // 1
        public string hash = ""; // "10990f1892354ac9f11d634332041f2616e31ceb87fbc9077ac615cdf22c0d51"
        public int vout_sz = 0; // 2

        //public void parseFromDict(Dictionary<string, object> transactionDict)
        public void parseFromDict(JSONNode transactionDict)
        {
            if (transactionDict["ver"] != null)
            {
                //this.ver = int.Parse((string)transactionDict["ver"]);
                this.ver = transactionDict["ver"].AsInt;
            }

            if (transactionDict["weight"] != null)
            {
                this.weight = transactionDict["weight"].AsInt;
            }

            if (transactionDict["relayed_by"] != null)
            {
                this.relayed_by = transactionDict["relayed_by"].Value;
            }

            if (transactionDict["lock_time"] != null)
            {
                this.lock_time = transactionDict["lock_time"].AsDouble;
            }

            if (transactionDict["size"] != null)
            {
                this.size = transactionDict["size"].AsInt;
            }

            if (transactionDict["rbf"] != null)
            {
                this.rbf = transactionDict["rbf"].AsBool;
            }

            if (transactionDict["double_spend"] != null)
            {
                this.double_spend = transactionDict["double_spend"].AsBool;
            }

            if (transactionDict["time"] != null)
            {
                this.time = transactionDict["time"].AsDouble;
            }

            if (transactionDict["tx_index"] != null)
            {
                this.tx_index = transactionDict["tx_index"].AsDouble;
            }

            if (transactionDict["vin_sz"] != null)
            {
                this.vin_sz = transactionDict["vin_sz"].AsInt;
            }

            if (transactionDict["hash"] != null)
            {
                this.hash = transactionDict["hash"].Value;
            }

            if (transactionDict["vout_sz"] != null)
            {
                this.vout_sz = transactionDict["vout_sz"].AsInt;
            }
        }

        public string printToString()
        {
            string tempLog = "";

            tempLog += "\t";
            tempLog += " ver: " + this.ver;
            tempLog += "\n";

            tempLog += "\t";
            tempLog += " weight: " + this.weight;
            tempLog += "\n";

            tempLog += "\t";
            tempLog += " relayed_by: " + this.relayed_by;
            tempLog += "\n";

            tempLog += "\t";
            tempLog += " lock_time: " + this.lock_time;
            tempLog += "\n";

            tempLog += "\t";
            tempLog += " size: " + this.size;
            tempLog += "\n";

            tempLog += "\t";
            tempLog += " rbf: " + this.rbf;
            tempLog += "\n";

            tempLog += "\t";
            tempLog += " double_spend: " + this.double_spend;
            tempLog += "\n";

            tempLog += "\t";
            tempLog += " time: " + this.time;
            tempLog += "\n";

            tempLog += "\t";
            tempLog += " tx_index: " + this.tx_index;
            tempLog += "\n";

            tempLog += "\t";
            tempLog += " vin_sz: " + this.vin_sz;
            tempLog += "\n";

            tempLog += "\t";
            tempLog += " hash: " + this.hash;
            tempLog += "\n";

            tempLog += "\t";
            tempLog += " vout_sz: " + this.vout_sz;
            tempLog += "\n";

            return tempLog;
        }
    } // Transaction

    public string parseGetTransactionInfoResponse(string jsonString)
        {
        if ((jsonString == null) || (jsonString.Length == 0))
        {
            string errorStr = "parseGetAccountBalanceResponse: invalid jsonString!\n";
            Debug.Log(errorStr);
            return errorStr;
        }

        string messageLog = "";

        /* unverified
	        {
	           "ver":1,
	           "inputs":[
		          {
			         "sequence":4294967293,
			         "witness":"",
			         "prev_out":{
				        "spent":true,
				        "tx_index":279688050,
				        "type":0,
				        "addr":"1FSUEaWewRYqLV8HSCFn4QiCgvFG539QPh",
				        "value":1954003,
				        "n":0,
				        "script":"76a9149e62e4d6931db5e7aa92584e2571c519b018b36188ac"
			         },
			         "script":"473044022031985b723d0fe9197ec4f29f91463a4e7959216a9c646bf50c13dae2e40772e402206a6715e7cf53f9967e95769bfc58a892eab32bc66034b35a6c4963c90995f9d7014104031aae54295f06a0dcb4b0f4b2e84a921598353b4aa2791cf0ecb82222809ce9330b9a6aa352c8714b3154f79be3231e8bca263b3b8ff9df5bc3c1aa3d68f9eb"
		          }
	           ],
	           "weight":1028,
	           "relayed_by":"0.0.0.0",
	           "out":[
		          {
			         "spent":false,
			         "tx_index":309671994,
			         "type":0,
			         "addr":"1C53cU1oqmqwco38ZawdVQqVemaqa7aWQi",
			         "value":300000,
			         "n":0,
			         "script":"76a914796d3a384751a6bb4e26bb06b49570e17544ea7088ac"
		          },
		          {
			         "spent":false,
			         "tx_index":309671994,
			         "type":0,
			         "addr":"1FSUEaWewRYqLV8HSCFn4QiCgvFG539QPh",
			         "value":1584000,
			         "n":1,
			         "script":"76a9149e62e4d6931db5e7aa92584e2571c519b018b36188ac"
		          }
	           ],
	           "lock_time":498171,
	           "size":257,
	           "rbf":true,
	           "double_spend":false,
	           "time":1512701214,
	           "tx_index":309671994,
	           "vin_sz":1,
	           "hash":"10990f1892354ac9f11d634332041f2616e31ceb87fbc9077ac615cdf22c0d51",
	           "vout_sz":2
	        }
         */
        //var dict = Json.Deserialize(jsonString) as Dictionary<string, object>;
        JSONNode dict = JSON.Parse(jsonString);
        //if (debugLevel > 0) Debug.Log("deserialized: " + dict.GetType());

        Transaction tx = new BlockchainDataManager.Transaction();
        tx.parseFromDict(dict);

        messageLog += tx.printToString();
        Debug.Log(messageLog);

        return messageLog;
    }

}