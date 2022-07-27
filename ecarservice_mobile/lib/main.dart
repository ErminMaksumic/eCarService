import 'package:flutter/material.dart';
import 'package:flutterv1/providers/offer_provider.dart';
import 'package:flutterv1/providers/user_provider.dart';
import 'package:flutterv1/screens/offers_screen.dart';
import 'package:flutterv1/utils/util.dart';
import 'package:provider/provider.dart';

void main() {
  runApp(MultiProvider(
    providers: [
      ChangeNotifierProvider(create: (_) => OfferProvider()),
      ChangeNotifierProvider(create: (_) => UserProvider()),
    ],
    child: const MyApp(),
  ));
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo!',
      theme: ThemeData(
        primarySwatch: Colors.blueGrey,
      ),
      home: const MyHomePage(title: 'eCarService'),
      onGenerateRoute: (settings) {
        if(settings.name == OfferListScreen.routeName)
        {
          return MaterialPageRoute(builder: (context)=> OfferListScreen());
        }
      },
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({Key? key, required this.title}) : super(key: key);

  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {

  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  late UserProvider _userProvider;

  @override
  Widget build(BuildContext context) {

    //_userProvider = context.read<UserProvider>();
    _userProvider = Provider.of(context, listen: false);
  
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 350,
              decoration: BoxDecoration(
                image: DecorationImage(
                  image: AssetImage('assets/images/background.png'),
                  fit: BoxFit.fill
                )),
                child: Stack(
                  children: [
                    Container(
                      margin: EdgeInsets.only(top: 280),
                      child: Center(
                        child: Center(
                          child: Text("Login", 
                          style:TextStyle(color: Colors.cyan, fontSize: 40, fontWeight: FontWeight.bold),)),
                      ),
                    )
                  ],
                ),
            ),
            Padding(padding: EdgeInsets.all(50),
            child: Column(children: [
              Container(
                padding: EdgeInsets.all(10),
                decoration: BoxDecoration(
                  color: Colors.white,
                  borderRadius: BorderRadius.circular(10)
                ),
                child: TextField(
                  controller: _usernameController,
                  decoration: InputDecoration(border: InputBorder.none, hintText: "Username", 
                  hintStyle: TextStyle(color: Colors.cyan)),
                ),
              ),
              Container(
                padding: EdgeInsets.all(10),
                decoration: BoxDecoration(
                  border: Border(top: BorderSide(color: Colors.black), bottom: BorderSide(color: Colors.black)
                  )
                ),

                child: TextField(
                   controller: _passwordController,
                   decoration: InputDecoration(border: InputBorder.none, hintText: "Password",
                   hintStyle: TextStyle(color: Colors.cyan)),
                ),
              ),
            ],),),
            Container(
                height: 50,
                margin: EdgeInsets.fromLTRB(45, 0, 45, 0),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(10),
                  gradient: LinearGradient(
                    colors: [Colors.cyan, Colors.blue ]
                  )
                ),
                child: InkWell(
                  onTap: () async {
                  try {
                        Authorization.username = _usernameController.text;
                        Authorization.password = _passwordController.text;
                        await _userProvider.login();
                        Navigator.pushNamed(context, OfferListScreen.routeName);
                      } on Exception catch (e) {
                        showDialog(
                          context: context,
                          builder: (BuildContext context) => AlertDialog(
                          title: Text("Login failed"),
                          content: Text("Invalid username and/or password"),
                          actions: [
                            TextButton(
                              child: Text("Ok"),
                              onPressed: () => Navigator.pop(context),)
                          ],
                        ));
                    }
                  },
                  child: Center(child: Text("Login")),
                )
              )
          ],
        ),
      )
    );
  }
}
