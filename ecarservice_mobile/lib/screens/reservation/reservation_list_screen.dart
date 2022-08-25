import 'dart:ui';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutterv1/model/part.dart';
import 'package:flutterv1/providers/offer_provider.dart';
import 'package:flutterv1/providers/reservation_provider.dart';
import 'package:flutterv1/screens/user/profile_screen.dart';
import 'package:flutterv1/screens/offers/rating_screen.dart';
import 'package:flutterv1/utils/user.dart';
import 'package:flutterv1/utils/util.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../../model/offer.dart';
import '../../model/rating.dart';
import '../../model/reservation.dart';
import '../../widgets/master_screen.dart';

class ReservationListScreen extends StatefulWidget {
  static const String routeName = "/reservationList";
  const ReservationListScreen({Key? key}) : super(key: key);

  @override
  State<ReservationListScreen> createState() =>
      _ReservationListScreenScreenState();
}

class _ReservationListScreenScreenState extends State<ReservationListScreen> {
  ReservationProvider? _reservationProvider;
  List<Reservation> data = [];

  final TextEditingController _searchController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _reservationProvider = context.read<ReservationProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData =
        await _reservationProvider?.get({'userId': UserLogin.user!.userId});

    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      index: 0,
      child: SingleChildScrollView(
        child: Column(children: buildAll()),
      ),
    );
  }

  List<Widget> buildAll() {
    List<Widget> list = <Widget>[];

    list.add(_buildHeader());
    list.add(_buildOfferSearch());
    list.addAll(_buildCard());

    return list;
  }

  List<Widget> _buildProductCardList() {
    if (data.isEmpty) {
      return [const Text("Loading...")];
    }

    List<Widget> list = data
        .map((x) => Container(
              height: 200,
              width: 200,
              child: Column(
                children: [
                  Text(x.offer!.name ?? ""),
                  Text(formatNumber(x.offer!.price)),
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }

  Widget _buildHeader() {
    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: const Text(
        "My reservations",
        style: TextStyle(
            color: Colors.cyan, fontWeight: FontWeight.bold, fontSize: 40),
      ),
    );
  }

  Widget _buildOfferSearch() {
    return Column(
      children: [
        Row(
          children: [
            Expanded(
              child: Container(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
                  child: TextField(
                    controller: _searchController,
                    onSubmitted: (value) async {
                      var tempData = await _reservationProvider?.get({
                        'userId': UserLogin.user!.userId,
                        "name": _searchController.text
                      });
                      setState(() {
                        data = tempData!;
                      });
                    },
                    decoration: const InputDecoration(
                        hintText: "Search by offer name",
                        prefixIcon: Icon(Icons.search),
                        border: OutlineInputBorder(
                          borderSide: BorderSide(color: Colors.grey),
                        )),
                  )),
            ),
          ],
        ),
        Container(
          padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 10),
          child: IconButton(
            icon: Icon(Icons.filter_list),
            color: Colors.cyan,
            onPressed: () async {
              var tempData = await _reservationProvider?.get({
                'name': _searchController.text,
              });
              setState(() {
                data = tempData!;
              });
            },
          ),
        ),
      ],
    );
  }

  List<Widget> _buildCard() {
    if (data.length == 0) return [const Text("Loading data")];

    List<Widget> list = data
        .map(
          (x) => Padding(
            padding: const EdgeInsets.all(10.0),
            child: Container(
              decoration: BoxDecoration(
                  border: Border.all(),
                  color: Colors.grey,
                  borderRadius: BorderRadius.all(Radius.circular(20))),
              child: Container(
                  child: Stack(
                children: [
                  Column(
                    children: [
                      Container(
                        height: 130,
                        child: Column(
                          children: [
                            Row(
                              mainAxisAlignment: MainAxisAlignment.center,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text(
                                  x.offer!.name!,
                                  textAlign: TextAlign.center,
                                  style: const TextStyle(
                                      color: Colors.black,
                                      fontWeight: FontWeight.bold,
                                      fontSize: 25),
                                ),
                              ],
                            ),
                            SizedBox(height: 10),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.start,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "- Date:  ",
                                  textAlign: TextAlign.center,
                                  style: TextStyle(
                                      color: Colors.black, fontSize: 15),
                                ),
                                Text(x.date.toString(),
                                    textAlign: TextAlign.center,
                                    style: const TextStyle(
                                        color: Colors.black,
                                        fontWeight: FontWeight.bold,
                                        fontSize: 15))
                              ],
                            ),
                            const SizedBox(
                              height: 5,
                            ),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.start,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "- Status:  ",
                                  textAlign: TextAlign.center,
                                  style: TextStyle(
                                      color: Colors.black, fontSize: 15),
                                ),
                                Text(x.status!,
                                    textAlign: TextAlign.center,
                                    style: TextStyle(
                                        color: x.status == "Active" ||
                                                x.status == "active"
                                            ? Colors.red
                                            : Colors.green,
                                        fontSize: 15,
                                        fontWeight: FontWeight.bold))
                              ],
                            ),
                            const SizedBox(
                              height: 5,
                            ),
                            Row(
                              mainAxisAlignment: MainAxisAlignment.start,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                const Text(
                                  "- Price: ",
                                  textAlign: TextAlign.center,
                                  style: TextStyle(
                                      color: Colors.black, fontSize: 15),
                                ),
                                Text("${formatNumber(x.offer!.price)} \$",
                                    textAlign: TextAlign.center,
                                    style: const TextStyle(
                                        color: Colors.black,
                                        fontWeight: FontWeight.bold,
                                        fontSize: 15))
                              ],
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ],
              )),
            ),
          ),
        )
        .cast<Widget>()
        .toList();
    return list;
  }
}
