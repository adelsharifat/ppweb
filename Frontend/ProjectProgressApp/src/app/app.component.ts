import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';

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
  constructor(private router:Router){



  }

  ngOnInit(): void {
    window.addEventListener('beforeinstallprompt', (e) => {
      e.preventDefault();
      this.deferredPrompt = e;
      this.showAppInstallerBanner = true;
    });
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
