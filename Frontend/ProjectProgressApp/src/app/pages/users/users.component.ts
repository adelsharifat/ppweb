import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/data/service/auth.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {


  fg:FormGroup = this.fb.group({
    userName:['',Validators.required],
    password:['',Validators.required],
    firstName:['',Validators.required],
    lastName:['',Validators.required],
    isAdmin:[false,Validators.required]
  })

  constructor(private fb:FormBuilder, private authService:AuthService) { }

  ngOnInit(): void {
  }

  register(){
    console.log(this.fg.value)
    this.authService.register(this.fg.value).subscribe(
      res=>{
        console.log(res.payload)
      },
      err=>{
        console.log(err)
      }
    )
  }

}
