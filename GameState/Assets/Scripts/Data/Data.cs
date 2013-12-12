using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class Data
{
    //	private static Data data;
    //
    //	private  Data(){}
    //	public static Data GetData(){
    //		if(data== null){	
    //			data=new Data();
    //		}
    //		return data;
    //	}
    List<ServerEntity> list;

    public List<ServerEntity> GetData()
    {
        if (list == null)
        {
            list = new List<ServerEntity>();
            LoadServerData();
        }
        return list;
    }

    void LoadServerData()
    {
        XmlDocument xmlDoc = new XmlDocument();
		#if UNITY_STANDALONE_WIN
			xmlDoc.Load(@"Assets/Resources/data.xml");
		#endif
        
		if(Application.isEditor){
			xmlDoc.Load(Application.dataPath + @"/Resources/data.xml");
		}
		else if(Application.isWebPlayer){
			xmlDoc.Load(@"/Resources/data.xml");
		}

        //获取root下子节点
        XmlNodeList nodes = xmlDoc.SelectSingleNode("root").ChildNodes;
        //遍历
        foreach (XmlNode item in nodes)
        {
            GetNodes(item);
        }
    }
    //获取节点
    void GetNodes(XmlNode node)
    {
        string serverName = node.Attributes["serverName"].Value;
        string serverId = node.Attributes["serverId"].Value;
        int parentId = 0;
        //判断是否小区
        if (node.ParentNode.Attributes["serverId"] != null)
        {
            //获取父级server id
            int.TryParse(node.ParentNode.Attributes["serverId"].Value, out parentId);
        }
        //添加到list中
        ServerEntity entity = new ServerEntity();
        entity.ServerId = serverId;
        entity.ServerName = serverName;
        entity.ParentId = parentId;
        list.Add(entity);
        //		list.Add(
        //			new ServerEntity(){
        //			ServerId=serverId,
        //			ServerName=serverName,
        //			ParentId=parentId
        //		});
        //递归获取节点
        foreach (XmlNode xn in node.ChildNodes)
            GetNodes(xn);
    }
}

public class ServerEntity
{

    /// <summary>
    /// 服务器id
    /// </summary>
    /// <value>The server identifier.</value>
    public string ServerId { get; set; }

    /// <summary>
    /// 服务器名字
    /// </summary>
    /// <value>The name of the server.</value>
    public string ServerName { get; set; }

    /// <summary>
    /// 父级id
    /// </summary>
    /// <value>The parent identifier.</value>
    public int ParentId { get; set; }
}
