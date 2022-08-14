import 'dart:ui';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:flutterv1/screens/rating_screen.dart';
import 'package:flutterv1/utils/user.dart';
import 'package:flutterv1/widgets/master_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import '../model/offer.dart';
import '../providers/offer_provider.dart';
import '../utils/util.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

class OfferDetailsScreen extends StatefulWidget {
  static const String routeName = "/offer_details";
  String id;
  OfferDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<OfferDetailsScreen> createState() => _OfferDetailsScreenScreenState();
}

class _OfferDetailsScreenScreenState extends State<OfferDetailsScreen> {
  OfferProvider? _offerProvider;
  Offer? data;

  @override
  void initState() {
    super.initState();
    _offerProvider = context.read<OfferProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _offerProvider?.getById(int.parse(widget.id));
    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    if (data == null) {
      return const Text('');
    }

    return MasterScreenWidget(
      index: 0,
      child: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 200,
              width: 500,
              child: Image.memory(dataFromBase64String(data!.image!),
                  fit: BoxFit.cover),
            ),
            Align(
              alignment: Alignment.bottomCenter,
              child: Container(
                height: MediaQuery.of(context).size.height * 0.7,
                width: MediaQuery.of(context).size.width * 1,
                decoration: const BoxDecoration(
                    color: Color.fromARGB(255, 54, 53, 50),
                    borderRadius: BorderRadius.only(
                      topLeft: Radius.circular(10),
                      topRight: Radius.circular(10),
                    ),
                    boxShadow: [
                      BoxShadow(
                          color: Colors.cyan,
                          offset: Offset(0, -4),
                          blurRadius: 8)
                    ]),
                child: Column(
                  children: [
                    Padding(
                      padding:
                          const EdgeInsets.only(top: 20, left: 20, right: 20),
                      child: Row(
                        children: [
                          Expanded(
                            child: Text(
                              data!.name!,
                              style: const TextStyle(
                                  fontSize: 36,
                                  fontWeight: FontWeight.bold,
                                  color: Colors.white),
                            ),
                          ),
                        ],
                      ),
                    ),
                    Padding(
                      padding:
                          const EdgeInsets.only(top: 20, left: 20, right: 20),
                      child: Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: [
                          const Text(
                            'Price: ',
                            style: TextStyle(
                                fontSize: 20,
                                fontWeight: FontWeight.bold,
                                color: Colors.cyan),
                          ),
                          Text(
                            '${formatNumber(data!.price!)} \$',
                            style: const TextStyle(
                                fontSize: 20,
                                fontWeight: FontWeight.bold,
                                color: Colors.white),
                          ),
                        ],
                      ),
                    ),
                    Column(
                      children: [
                        Row(
                          children: [
                            Padding(
                              padding: const EdgeInsets.only(
                                  top: 30, left: 20, right: 20),
                              child: Row(
                                children: [
                                  Column(
                                    children: _buildParts(),
                                  ),
                                  const SizedBox(
                                    width: 80,
                                  ),
                                  Column(
                                    children: [
                                      Row(
                                        children: [
                                          Container(
                                            height: 40,
                                            width: 130,
                                            decoration: BoxDecoration(
                                                borderRadius:
                                                    BorderRadius.circular(10),
                                                gradient: const LinearGradient(
                                                    colors: [
                                                      Colors.cyan,
                                                      Colors.lightBlue
                                                    ])),
                                            child: InkWell(
                                              onTap: () async {
                                                // Navigator.pushNamed(context, RatingScreen.routeName, arguments: {'id': data!.offerId});
                                                UserLogin.offerId =
                                                    data!.offerId;
                                                Navigator.pushNamed(context,
                                                    RatingScreen.routeName);
                                              },
                                              child: const Center(
                                                  child:
                                                      Text("Rate this offer")),
                                            ),
                                          ),
                                        ],
                                      ),
                                      SizedBox(height: 20),
                                      Row(
                                        children: [
                                          Container(
                                            height: 40,
                                            width: 130,
                                            decoration: BoxDecoration(
                                                borderRadius:
                                                    BorderRadius.circular(10),
                                                gradient: const LinearGradient(
                                                    colors: [
                                                      Colors.cyan,
                                                      Colors.lightBlue
                                                    ])),
                                            child: InkWell(
                                              onTap: () async {},
                                              child: const Center(
                                                  child: Text(
                                                      "Reserve this offer")),
                                            ),
                                          ),
                                        ],
                                      ),
                                    ],
                                  ),
                                ],
                              ),
                            ),
                          ],
                        ),
                      ],
                    ),
                    Padding(
                      padding:
                          const EdgeInsets.only(top: 30, left: 20, right: 20),
                      child: Row(
                        children: [
                          Column(
                            children: _buildBrands(),
                          ),
                          const SizedBox(
                            width: 60,
                          ),
                        ],
                      ),
                    ),
                    const SizedBox(
                      height: 70,
                    ),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

  List<Widget> _buildParts() {
    List<Widget> list = data!.parts!
        .map(
          (x) => Row(
            children: [
              Text(
                x.name!,
                style: const TextStyle(fontSize: 20, color: Colors.white),
              ),
              const Icon(
                Icons.settings,
                color: Colors.green,
              ),
            ],
          ),
        )
        .cast<Widget>()
        .toList();

    list.insert(
        0,
        Container(
          margin: const EdgeInsets.only(bottom: 20),
          child: const Text("Including parts: ",
              style:
                  TextStyle(color: Colors.cyan, fontWeight: FontWeight.bold)),
        ));

    return list;
  }

  List<Widget> _buildBrands() {
    List<Widget> list = data!.carBrands!
        .map(
          (x) => Row(
            children: [
              Text(
                x.name!,
                style: const TextStyle(fontSize: 20, color: Colors.white),
              ),
              const Icon(
                Icons.car_repair,
                color: Colors.green,
              ),
            ],
          ),
        )
        .cast<Widget>()
        .toList();

    list.insert(
        0,
        Container(
          margin: const EdgeInsets.only(bottom: 20),
          child: const Text("Service for brands: ",
              style:
                  TextStyle(color: Colors.cyan, fontWeight: FontWeight.bold)),
        ));

    return list;
  }
}
