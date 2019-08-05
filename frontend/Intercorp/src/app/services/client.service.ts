import { Injectable } from '@angular/core';
import { AngularFireDatabase } from '@angular/fire/database';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  constructor(private angularFireDatabase: AngularFireDatabase) { }

  getClients() {
    return this.angularFireDatabase.list('/clients');
  }

  getClientById(uid){
    return this.angularFireDatabase.object('/clients/' + uid);
  }

  createClient(client){
    return this.angularFireDatabase.object('/clients/' + client.uid).set(client);
  }

  editClient(client){
    return this.angularFireDatabase.object('/clients/' + client.uid).set(client);
  }
}
