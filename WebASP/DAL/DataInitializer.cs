using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebASP.Models;

namespace WebASP.DAL
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var typecousre = new List<TypeCourse>
            {
                new TypeCourse{TypeCourseID="1",TypeName="TIẾNG ANH MẦM NON",Introduce="Là khóa học được thiết kế riêng cho các bé mẫu giáo từ 4-6 tuổi với chương trình học vui nhộn, lắng nghe giữa học và chơi; giúp các bé phát triển thể chất, năng khiếu ngoại ngữ với những nội dung phù hợp lứa tuổi.",UrlImg=("/Content/img/1.jpg")},
                new TypeCourse{TypeCourseID="2",TypeName="TIẾNG ANH THIẾU NHI",Introduce="Là chương trình tiếng Anh thiếu nhi được thiết kế cho các bé từ 6 đến 11 tuổi. Sử dụng phương pháp học toàn diện English+21 và giáo trình Story Central, các bé sẽ học mà chơi trong thế giới Tiếng Anh tràn ngập những câu chuyện tuyệt vời và khám phá cuộc sống nhiều màu sắc.",UrlImg=("/Content/img/2.jpg")},
                new TypeCourse{TypeCourseID="3",TypeName="TIẾNG ANH THIẾU NIÊN",Introduce="Là chương trình tiếng Anh thiếu niên được thiết kế cho các học viên từ 12 đến 16 tuổi. Sử dụng phương pháp học toàn diện English+21 và giáo trình Beyond, học viên sẽ tiếp cận và nâng cao khả năng tiếng Anh với những bài học đa dạng, đa văn hóa thú vị và đặc sắc.",UrlImg=("/Content/img/3.jpg")},
                new TypeCourse{TypeCourseID="4",TypeName="TIẾNG ANH TOIEC",Introduce="Chương trình tiếng Anh doanh nghiệp được thiết kế riêng và phù hợp với yêu cầu của từng khách hàng. Nâng cao kỹ năng Tiếng Anh cho nguồn nhân lực ngay chính tại doanh nghiệp, giúp tiết kiệm thời gian, chi phí và áp dụng được ngay trong công việc.",UrlImg=("/Content/img/4.jpg")},

            };
            typecousre.ForEach(s => context.TypeCourse.Add(s));
            context.SaveChanges();
        }
    }
}