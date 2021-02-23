import { Component, OnInit } from '@angular/core';
import { HomeService } from './home.service';
import { Skier } from '../_models/skier';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  skier = new Skier();
  skierForm: FormGroup;
  recommendationToggle = false;
  variableLengthToggle = false;

  constructor(private homeService: HomeService) { }

  ngOnInit(): void {
    this.createSkierForm();
  }

  createSkierForm() {
    this.skierForm = new FormGroup({
      age: new FormControl('', Validators.required),
      height: new FormControl('', Validators.required),
      discipline: new FormControl('', Validators.required)
    })
  }

  submitSkierForm() {
    var age = this.skierForm.controls['age'].value;
    var height = this.skierForm.controls['height'].value;
    var discipline = this.skierForm.controls['discipline'].value;

    this.getRecommendation(age, height, discipline);
    this.recommendationToggle = true;
  }

  getRecommendation(age: number, height: number, discipline: string) {
    this.homeService.getRecommendation(age, height, discipline).subscribe((response) => {
      this.skier = response;
      if (this.skier.variableLength == true) {
        this.variableLengthToggle = true;
      }
    }, error => {
        console.log(error);
        this.recommendationToggle = false;
    });
  }

}
