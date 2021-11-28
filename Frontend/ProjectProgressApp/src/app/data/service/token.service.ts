import { Injectable } from '@angular/core';


const TOKEN_KEY = 'token';
const REFRESHTOKEN_KEY = 'refreshtoken';
const USER_KEY = 'user';


@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor() { }

  signOut(): void {
    window.localStorage.clear();
  }

  public saveToken(token: string): void {
    window.localStorage.removeItem(TOKEN_KEY);
    window.localStorage.setItem(TOKEN_KEY, token);
  }

  public getToken(): string | null | undefined {
    return window.localStorage.getItem(TOKEN_KEY);
  }

  public saveRefreshToken(token: string): void {
    window.localStorage.removeItem(REFRESHTOKEN_KEY);
    window.localStorage.setItem(REFRESHTOKEN_KEY, token);
  }

  public getRefreshToken(): string | null | undefined {
    return window.localStorage.getItem(REFRESHTOKEN_KEY);
  }

}
