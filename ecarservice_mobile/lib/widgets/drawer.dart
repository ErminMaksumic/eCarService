import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutterv1/screens/user/login_screen.dart';
import 'package:flutterv1/screens/offers/offers_screen.dart';
import '../utils/util.dart';
import 'package:flutter/material.dart';

class DrawerMenu extends StatelessWidget {
  const DrawerMenu({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        children: [
          ListTile(
            title: const Text('Offers'),
            onTap: () {
              Navigator.pushNamed(context, OfferListScreen.routeName);
            },
          ),
          ListTile(
            title: const Text('Logout'),
            onTap: () {
              // Authorization.password = null;
              // Authorization.username = null;
              Navigator.popAndPushNamed(context, LoginScreen.routeName);
            },
          ),
        ],
      ),
    );
  }
}
