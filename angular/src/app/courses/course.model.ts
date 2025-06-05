export interface CourseDto {
  id: string;
  title: string;
  description: string;
  price: number;
  courseType: string;
  seatsAvailable: number;
  duration: number;
  thumbnail: string;
  // ...other fields as needed
}
