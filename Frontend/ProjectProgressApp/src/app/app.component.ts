import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { SwUpdate } from '@angular/service-worker';
import { AuthService } from './data/service/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'ODCC-ARUP';
  isShow = false;
  showAppInstallerBanner = false;
  deferredPrompt:any;
  constructor(private router:Router,private swUpdate:SwUpdate,private authService:AuthService){
    if(/like/i.test(navigator.userAgent)){

    }

    if(/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)){
      // true for mobile device

      this.updateClient();


      window.addEventListener('beforeinstallprompt', (e) => {
        e.preventDefault();
        this.deferredPrompt = e;
        this.showAppInstallerBanner = true;
      });

    }else if(this.authService.seenDesktopMode()==="False"){
      // false for not mobile device
      this.router.navigate(['/privacy'])
      return;
    }
  }

  ngOnInit(): void {

  }

  updateClient(){
    if(!this.swUpdate.isEnabled){
      return;
    }
    this.swUpdate.available.subscribe((event)=>{
      if(event)
      {
          this.swUpdate.activateUpdate().then(()=>{
            if(confirm("The new version avilable for update, click Ok!")){
              location.reload();
            }
          })
      }
    })
  }


  installPrompt() {
    this.deferredPrompt.prompt();
    this.deferredPrompt.userChoice.then((choiceResult:any) => {
      if (choiceResult.outcome === 'accepted') {
        this.showAppInstallerBanner = false;
      } else {
      }
      this.deferredPrompt = null;
    });
  }
}
