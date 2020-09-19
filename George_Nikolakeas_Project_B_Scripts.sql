Select * from CourseList
Select * from TrainerList
Select * from StudentList
Select * from AssignmentList
Select * from TrainersPerCourse
Select * from StudentsPerCourse


--Shows Assignments per Course
select c.*,a.* from Courses as c,Course_Assignments as ca,Assignments as a
where c.CourseID = ca.CourseID and ca.AssID = a.AssID

--Same as above but i cant save view that has same column names
select * from WeirdView_AssPerCourse

--Shows Students--- that have Assignments --- from Course
--Student 1 -- has Assignment 1 -- from Course1
--student 2 -- has Assignment 2 -- from Course1
--Student 2 -- has Assignment 2 -- From Course 2

select s.*,a.*,c.* from Assignments as a, Students as s,Course_Students as cs,
Course_Assignments as ca,Courses as c
where c.CourseID = cs.CourseID and c.CourseID = ca.CourseID and
cs.StudentID = s.StudentID and a.AssID = ca.AssID


--Same as above, doesnt show any data from courses and no duplicate student-assignment
select distinct s.*,a.*
from Assignments as a, Students as s, Course_Assignments as ca,
Course_Students as cs
where ca.CourseID = cs.CourseID and cs.StudentID = s.StudentID and Ca.AssID = a.AssID
order by s.StudentID


--Shows students that have more than 1 course

select s.StudentID,s.FirstName,s.LastName,s.DateOfBirth,
s.TuitionFee,count(1) as 'Has Courses' from Students as s,Course_Students as cs
where s.StudentID = cs.StudentID 
group by s.STudentID,s.Firstname,s.LastName,s.DateOfBirth,
s.TuitionFee
having count(1) > 1
