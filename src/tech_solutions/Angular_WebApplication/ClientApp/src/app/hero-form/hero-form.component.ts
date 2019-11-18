import { Component, OnInit } from '@angular/core';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Hero } from '../hero';
@Component({
  selector: 'app-hero-form',
  templateUrl: './hero-form.component.html',
  styleUrls: ['./hero-form.component.css']
})
export class HeroFormComponent implements OnInit {

    heroForm = new FormGroup({
        name: new FormControl(''),
        alterEgo: new FormControl(''),
        power: new FormControl('')
    });


    powers = ['Really Smart', 'Super Flexible',
        'Super Hot', 'Weather Changer'];

    model = new Hero(18, 'Dr IQ', this.powers[0], 'Chuck Overstreet');

    submitted = false;

    onSubmit() {
        this.submitted = true;
        console.log("submit");
        console.log(JSON.stringify(this.heroForm.value));
    }

    // TODO: Remove this when we're done
    get diagnostic() { return JSON.stringify(this.model); }
  constructor() { }

    ngOnInit() {

  }


}
