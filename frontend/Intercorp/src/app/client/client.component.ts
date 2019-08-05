import { Component, OnInit } from '@angular/core';
import { ClientService } from '../services/client.service';
import { Client } from '../interfaces/client';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
export class ClientComponent implements OnInit {
  clients: Client[];
  client: Client;
  localCreate: boolean = false;
  ages: any[];
  average: number;
  avgAge: number;
  stdDev: number;
  
  constructor(private clientService: ClientService) {
    this.clientService.getClients().valueChanges().subscribe((data: Client[])=>{
      this.clients = data;
      this.ages = this.clients.map(i => {return {age: i.age}});
      this.carculateAverage();
    }, (error)=>{
      console.log(error);
    });
  }

  ngOnInit() {
  }

  showCreatePanel() {
    this.localCreate = true;
    this.client = {} as Client;
  }

  carculateAverage() {
    this.average = 0;
    const sum = 0;
    this.ages.forEach(function(element) {
      console.log(element.age);
      this.sum = element.age;
    });
  }

  create() {
    this.clientService.createClient(this.client).then(() => {
      this.localCreate = false;
      this.client = {} as Client;
    });
  }
}
