import 'package:flutterv1/screens/offers_screen.dart';
import 'package:flutterv1/screens/profile_screen.dart';
import 'package:provider/single_child_widget.dart';

import 'package:flutter/material.dart';

class MasterScreenWidget extends StatelessWidget {
  Widget? child;
  int? index = 0;
  MasterScreenWidget({this.child, this.index, Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Car service"),
      ),
      body: SafeArea(child: child!),
      bottomNavigationBar: BottomNavigationBar(
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            icon: Icon(Icons.home),
            label: 'Home',
          ),
          BottomNavigationBarItem(
            icon: Icon(Icons.person),
            label: 'My profile',
          ),
        ],
        currentIndex: index!,
        selectedItemColor: Colors.cyan,
        onTap: (index) {
          switch (index) {
            case 0:
              Navigator.pushNamed(context, OfferListScreen.routeName);
              break;
            case 1:
              Navigator.pushNamed(context, ProfileScreen.routeName);
              break;
          }
        },
      ),
    );
  }
}
