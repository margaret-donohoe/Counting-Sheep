using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Mirror.Discovery
{
    [DisallowMultipleComponent]
    [AddComponentMenu("Network/Network Discovery HUD")]
    [HelpURL("https://mirror-networking.gitbook.io/docs/components/network-discovery")]
    [RequireComponent(typeof(NetworkDiscovery))]
    public class CustomDiscovery : MonoBehaviour
    {
        readonly Dictionary<long, ServerResponse> discoveredServers = new Dictionary<long, ServerResponse>();
        Vector2 scrollViewPos = Vector2.zero;

        public NetworkDiscovery networkDiscovery;


        public Button start;
        public Button find;

        public Canvas discoveryHUD;

        public Button serverJoinPrefab;
        private ServerResponse currentServer;
        public GameObject[] buttonLocations;

#if UNITY_EDITOR
        void OnValidate()
        {
            if (networkDiscovery == null)
            {
                networkDiscovery = GetComponent<NetworkDiscovery>();
                UnityEditor.Events.UnityEventTools.AddPersistentListener(networkDiscovery.OnServerFound, OnDiscoveredServer);
                UnityEditor.Undo.RecordObjects(new Object[] { this, networkDiscovery }, "Set NetworkDiscovery");
            }
        }
#endif
        void Start()
        {

            Button startBtn = start.GetComponent<Button>();
            startBtn.onClick.AddListener(ClickStart);

            Button findBtn = find.GetComponent<Button>();
            findBtn.onClick.AddListener(ClickFind);
        }
        void OnGUI()
        {
            if (NetworkManager.singleton == null)
                return;

            if (!NetworkClient.isConnected && !NetworkServer.active && !NetworkClient.active)
                return;
        }

        void ClickStart()
        {
            discoveredServers.Clear();
            NetworkManager.singleton.StartHost();
            networkDiscovery.AdvertiseServer();
            DisableCanvas();
        }

        void ClickFind()
        {
            discoveredServers.Clear();
            networkDiscovery.StartDiscovery();
            EnableJoinBtns();

        }

        void EnableJoinBtns()
        {
            //waitOneSecond();
            Debug.Log($"Discovered Servers [{discoveredServers.Count}]:"); //not discovering any servers

            int buttonNum = 0;
                
            foreach (ServerResponse server in discoveredServers.Values)
            {
                currentServer = server;

                Debug.Log("???");


                if (buttonNum == 0)
                {
                    Button join1 = Instantiate(serverJoinPrefab, buttonLocations[0].transform);
                    join1.GetComponentInChildren<Text>().text = server.EndPoint.Address.ToString();
                    Button serv1 = join1.GetComponent<Button>();
                    serv1.onClick.AddListener(ClickConnect);
                }

                else if (buttonNum == 1)
                {
                    Button join2 = Instantiate(serverJoinPrefab, buttonLocations[1].transform);
                    join2.GetComponentInChildren<Text>().text = server.EndPoint.Address.ToString();
                    Button serv2 = join2.GetComponent<Button>();
                    serv2.onClick.AddListener(ClickConnect);
                }

                else if (buttonNum == 2)
                {
                    Button join3 = Instantiate(serverJoinPrefab, buttonLocations[2].transform);
                    join3.GetComponentInChildren<Text>().text = server.EndPoint.Address.ToString();
                    Button serv3 = join3.GetComponent<Button>();
                    serv3.onClick.AddListener(ClickConnect);
                }

                else if (buttonNum > 2)
                    return;

                buttonNum++;
            }
            
        }

        void ClickConnect()
        {
            Connect(currentServer);
        }

        void DrawGUI()
        {
            GUILayout.Label($"Discovered Servers [{discoveredServers.Count}]:");

            // servers
            scrollViewPos = GUILayout.BeginScrollView(scrollViewPos);

            foreach (ServerResponse info in discoveredServers.Values)
                if (GUILayout.Button(info.EndPoint.Address.ToString()))
                    Connect(info);

            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }

        //IEnumerator waitOneSecond()
        //{
        //    yield return new WaitForSeconds(1);
        //}

        //void StopButtons()
        //{
        //    GUILayout.BeginArea(new Rect(10, 40, 100, 25));

        //    // stop host if host mode
        //    if (NetworkServer.active && NetworkClient.isConnected)
        //    {
        //        if (GUILayout.Button("Stop Host"))
        //        {
        //            NetworkManager.singleton.StopHost();
        //            networkDiscovery.StopDiscovery();
        //        }
        //    }
        //    // stop client if client-only
        //    else if (NetworkClient.isConnected)
        //    {
        //        if (GUILayout.Button("Stop Client"))
        //        {
        //            NetworkManager.singleton.StopClient();
        //            networkDiscovery.StopDiscovery();
        //        }
        //    }
        //    // stop server if server-only
        //    else if (NetworkServer.active)
        //    {
        //        if (GUILayout.Button("Stop Server"))
        //        {
        //            NetworkManager.singleton.StopServer();
        //            networkDiscovery.StopDiscovery();
        //        }
        //    }

        //    GUILayout.EndArea();
        //}

        void Connect(ServerResponse info)
        {
            networkDiscovery.StopDiscovery();
            NetworkManager.singleton.StartClient(info.uri);
            DisableCanvas();
        }

        public void OnDiscoveredServer(ServerResponse info)
        {
            // Note that you can check the versioning to decide if you can connect to the server or not using this method
            discoveredServers[info.serverId] = info;
        }

        void DisableCanvas()
        {
            discoveryHUD.gameObject.SetActive(false);
            //ENABLE PAUSE BUTTON HERE   
        }
    }
}
