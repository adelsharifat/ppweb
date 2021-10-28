import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ToolbarService {

  constructor() { }

  public sidebarState = new BehaviorSubject<boolean>(false);

}
