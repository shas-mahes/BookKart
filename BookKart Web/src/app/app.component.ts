import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HomeComponent } from './Component/home/home.component';
import { NavBarComponent } from './Component/nav-bar/nav-bar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  imports: [RouterOutlet, HomeComponent, NavBarComponent],
})
export class AppComponent {
  title = 'BookKart';

  constructor() {}
}
