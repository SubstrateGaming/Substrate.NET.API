We implemented a basic bot to play, dot4g (extended version of connect four) over the SDK. This is still probably to deep for the SDK, we will remove later the Layer 2, so it is simpler in it's usage.

How to use:
```bat
git clone https://github.com/ajuna-network/backend-devel.git
git checkout polkadot-decoded
cd backend-devel
git submodule init
git submodule update
docker-compose build ajuna-node
docker-compose build worker
```

Get from NGROK a free auth token and fill it in the file .env
```bat
#In order to use ngrok paste your AUTH TOKEN here
AUTHTOKEN=
```

run nodes
```bat
docker-compose up
```

check log for the following information.
```bat
decoded-worker-1      | MRENCLAVE=Fdb2TM3owt4unpvESoSMTpVWPvCiXMzYyb42LzSsmFLi
```
```bat
decoded-worker-1      | t=2022-07-06T11:42:08+0000 lvl=info msg="started tunnel" obj=tunnels name=command_line addr=https://localhost:2000 url=https://4f20-84-75-48-249.ngrok.io
```

Now, we have all the information's to launch multiple bots to play.
```bat
git clone https://github.com/ajuna-network/Ajuna.NetApi.git
git checkout polkadot-decoded-1
cd Ajuna.NetApi
cd Dot4GBot
dotnet run
```

Execute it twice to have at least two players queueing up for a game, and add the informations previously gathered from the log.
![image](https://user-images.githubusercontent.com/17710198/177554943-4f577a3e-f016-4f3e-ac5b-4f28027bd6cc.png)

![image](https://user-images.githubusercontent.com/17710198/177555172-34766a69-865f-4da5-bc13-388506a82836.png)

