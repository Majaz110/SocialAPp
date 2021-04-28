import { CloneVisitor } from '@angular/compiler/src/i18n/i18n_ast';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import {AccountsService} from '../_services/accounts.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public accountService: AccountsService) { }

  model: any={};

  ngOnInit(): void {
  }

  login()
  {
    this.accountService.login(this.model).subscribe(response =>{
      console.log(response)
      },error =>
    {
      console.log(error);
    }
    );     
  }

  logout()
  {
    this.accountService.logout();
  }

}
