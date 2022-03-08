//using system.collections.generic;
//using tmpro;
//using unityengine;
//using unityengine.ui;

//public class gameselect : monobehaviour
//{
//    editor connections
//    public transform gamelistholder;
//    public gameobject gamebuttonprefab;

//    private void start()
//    {
//        updategamelist();
//    }

//    private void updategamelist()
//    {
//        //clear/remove the old list, if we have one.
//        foreach (transform child in gamelistholder)
//            destroy(child.gameobject);

//        //create new list, load each of the users active games
//        foreach (string gameid in playerdata.data.activegames)
//        {
//            savemanager.instance.loaddata("games/" + gameid, loadgameinfo);
//        }

//        //we have to few games, create a create game button
//        if (playerdata.data.activegames.count < 5)
//        {
//            var newbutton = instantiate(gamebuttonprefab, gamelistholder).getcomponent<button>();
//            newbutton.getcomponentinchildren<textmeshprougui>().text = "new game";
//            newbutton.onclick.addlistener(() => savemanager.instance.loaddata("games/", joinrandomgame));
//        }
//    }

//    create button for the games, and add onclick events with the corresponding game info.
//    public void loadgameinfo(string json)
//    {
//        var gameinfo = jsonutility.fromjson<gameinfo>(json);

//        var newbutton = instantiate(gamebuttonprefab, gamelistholder).getcomponent<button>();
//        newbutton.getcomponentinchildren<textmeshprougui>().text = gameinfo.displayname;
//    todo: display more game status on each button.

//    newbutton.onclick.addlistener(() => scenecontroller.instance.startgame(gameinfo));
//    }

//    public void creategame()
//    {
//        create a new game and start filling out the info.
//        var newgameinfo = new gameinfo();

//        newgameinfo.seed = random.range(0, int.maxvalue);
//        newgameinfo.displayname = playerdata.data.name + "'s game";

//        add the user as the first player
//        newgameinfo.players = new list<userinfo>();
//        newgameinfo.players.add(playerdata.data);

//        get a unique id for the game
//        string key = savemanager.instance.getkey("games/");
//        newgameinfo.gameid = key;

//        convert to json
//        string data = jsonutility.tojson(newgameinfo);

//        save our new game
//        string path = "games/" + key;
//        savemanager.instance.savedata(path, data);

//        add the key to our active games
//        gamecreated(key, newgameinfo);
//    }

//    public void gamecreated(string gamekey, gameinfo gameinfo)
//    {
//        //if we dont have any active games, create the list.
//        //playerdata.data.activegames ??= new list<string>();
//        //playerdata.data.activegames.add(gamekey);

//        //save our user with our new game
//        playerdata.savedata();

//        //start the game
//        scenecontroller.instance.startgame(gameinfo);
//    }

//    we will try to join a random game, if we can't we create a new game.
//public void joinrandomgame(list<string> data)
//    {
//        list<gameinfo> games = new list<gameinfo>();

//        foreach (var item in data)
//            games.add(jsonutility.fromjson<gameinfo>(item));

//        foreach (var activegame in games)
//        {
//            //don't list our own games or full games.
//            if (playerdata.data.activegames.contains(activegame.gameid) || activegame.players.count > 1)
//                continue;

//            joingame(activegame);
//            return;
//        }

//        //no random games to join, create a new game.
//        creategame();
//    }

//    public void joingame(gameinfo gameinfo)
//    {
//        debug.log("joining game: " + gameinfo.gameid);
//        playerdata.data.activegames.add(gameinfo.gameid);

//        //save our user with our new game
//        playerdata.savedata();

//        gameinfo.players.add(playerdata.data);

//        //update new game name
//        gameinfo.displayname = gameinfo.players[0].name + " vs " + playerdata.data.name;

//        string jsonstring = jsonutility.tojson(gameinfo);

//        //update the game
//        savemanager.instance.savedata("games/" + gameinfo.gameid, jsonstring);
//    }
//}