#include "bmp.h"
#include "measure.h"
#include "helpers.h"
#include <string>
#include <unordered_map>
#include "edge.cpp"

double run(int argc, char **argv, bool print = true);

char* basic_chessboard[] = {"edge", "chessboard.bmp", "chessboard_basic.bmp", "2"};
char* basic_jaguar[] = {"edge", "jaguar.bmp", "jaguar_basic.bmp", "2"};
char* basic_mandrill[] = {"edge", "mandrill.bmp", "mandrill_basic.bmp", "2"};
char* basic_mandrill_odd[] = {"edge", "mandrill_odd.bmp", "mandrill_odd_basic.bmp", "2"};
char* avx_chessboard[] = {"edge", "chessboard.bmp", "chessboard_user.bmp", "3"};
char* avx_jaguar[] = {"edge", "jaguar.bmp", "jaguar_user.bmp", "3"};
char* avx_mandrill[] = {"edge", "mandrill.bmp", "mandrill_user.bmp", "3"};
char* avx_mandrill_odd[] = {"edge", "mandrill_odd.bmp", "mandrill_odd_user.bmp", "3"};

std::unordered_map<std::string, double> percentages;

void chessboard_test(bool print = false)
{
    std::cout << "Testing chessboard..." << std::endl;
    double timing_basic, timing_AVX, temp_percent = 0;
    for(int i=0; i < 3; ++i)
    {
        timing_basic = run(std::size(basic_chessboard),basic_chessboard, print);
        timing_AVX = run(std::size(avx_chessboard),avx_chessboard, print);

        temp_percent += (timing_basic - timing_AVX) / timing_basic;
    }

    percentages["chessboard"] = temp_percent / 3;
    std::cout << "chessboard improvement: " << percentages["chessboard"] << std::endl;
}

void jaguar_test(bool print = false)
{
    std::cout << "Testing jaguar..." << std::endl;
    double timing_basic, timing_AVX, temp_percent = 0;
    for(int i=0; i < 3; ++i)
    {
        timing_basic = run(std::size(basic_jaguar),basic_jaguar, print);
        timing_AVX = run(std::size(avx_jaguar),avx_jaguar, print);

        temp_percent += (timing_basic - timing_AVX) / timing_basic;
    }

    percentages["jaguar"] = temp_percent / 3;
    std::cout << "jaguar improvement: " << percentages["jaguar"] << std::endl;
}


void mandrill_test(bool print = false)
{
    std::cout << "Testing mandrill..." << std::endl;
    double timing_basic, timing_AVX, temp_percent = 0;
    for(int i=0; i < 3; ++i)
    {
        timing_basic = run(std::size(basic_mandrill),basic_mandrill, print);
        timing_AVX = run(std::size(avx_mandrill),avx_mandrill, print);

        temp_percent += (timing_basic - timing_AVX) / timing_basic;
    }

    percentages["mandrill"] = temp_percent / 3;
    std::cout << "mandrill improvement: " << percentages["mandrill"] << std::endl;
}


void mandrill_odd_test(bool print = false)
{
    std::cout << "Testing mandrill_odd..." << std::endl;
    double timing_basic, timing_AVX, temp_percent = 0;
    for(int i=0; i < 3; ++i)
    {
        timing_basic = run(std::size(basic_mandrill_odd),basic_mandrill_odd, print);
        timing_AVX = run(std::size(avx_mandrill_odd),avx_mandrill_odd, print);

        temp_percent += (timing_basic - timing_AVX) / timing_basic;
    }

    percentages["mandrill_odd"] = temp_percent / 3;
    std::cout << "mandrill_odd improvement: " << percentages["mandrill_odd"] << std::endl;
}


int main(int argc, char **argv)
{
    if(argc < 3)
    {
        std::cout << 
            "Usage test <test: 0:all , 1:chessboard, 2:jaguar, 3:mandrill, 4:mandrill odd> <print?>"
            << std::endl;

        return 0;
    }

    int print = atoi(argv[2]);
    int test = atoi(argv[1]);

    percentages.clear();
    percentages.emplace("chessboard", 0.0);
    percentages.emplace("jaguar", 0.0);
    percentages.emplace("mandrill", 0.0);
    percentages.emplace("mandrill_odd", 0.0);

    switch(test)
    {
    case 0 :
        chessboard_test(print);
        jaguar_test(print);
        mandrill_test(print);
        mandrill_odd_test(print);
        
        break;
    case 1 :
        chessboard_test(print);
        break;
    case 2 :
        jaguar_test(print);
        break;
    case 3 :
        mandrill_test(print);
        break;
    case 4 :
        mandrill_odd_test(print);
        break;
    }

    return 0;
}

double run(int argc, char **argv, bool print)
{

    /* Some variables */
    bmp_header header;
    unsigned char *data_in, *data_out;
    unsigned int size;
    int rep;
#ifdef AVX_SUPPORT
    test_func functions[4] =
        { basic_sobel_edge_detection, avx_sobel_edge_detection,
        basic_kirsch_operator, avx_kirsch_edge_detection
    };
#else
    test_func functions[4] =
        { basic_sobel_edge_detection, sse_sobel_edge_detection,
        basic_kirsch_operator, sse_kirsch_edge_detection
    };
#endif
    if (argc != 4) {
#ifdef AVX_SUPPORT
		printf
		("Usage: edge <InFile> <OutFile> <0:basic_sobel, 1 :avx_sobel, 2: basic_kirsch , 3:avx_kirsch>\n\n");
#else
		printf
		("Usage: edge <InFile> <OutFile> <0:basic_sobel, 1 :sse_sobel, 2: basic_kirsch , 3:sse_kirsch>\n\n");

#endif

		exit(0);
    }

    bmp_read(argv[1], &header, &data_in);

    /* Size of image and output buffer */
    size = header.height * header.width;
    data_out = new unsigned char[3 * size];
    memcpy_s(data_out, 3 * size, data_in, 3 * size);

    if(print)
        printf("Resolution: (%d,%d) -> Size: %d\n", header.height,
            header.width, size);
    prof_time_t start = 0, end = 0;
    start_measure(start);
    sleep(1);
    end_measure(end);

    prof_time_t num_of_cycles_per_sec = end - start;

    int which_func = atoi(argv[3]);
    std::string fn_name;
    switch(which_func)
    {
    case 0 :
        fn_name = "basic_sobel";
        break;
    case 1 :
        fn_name = "avx/sse_sobel";
        break;
    case 2 :
        fn_name = "basic_kirsch";
        break;
    case 3 :
        fn_name = "avx/sse_kirsch";
        break;
    }

    if(print)
        printf("Running %s \n", fn_name.c_str());

    start_measure(start);
    end_measure(end);

    prof_time_t base_time = end - start;
    start_measure(start);
    for (rep = 0; rep < REP; rep++) {
        functions[which_func] (data_out, data_in, header.height,
                               header.width);
    }
    end_measure(end);

    prof_time_t cycles_taken = end - start - base_time;
    double timing = (cycles_taken / REP) / ((double) num_of_cycles_per_sec);

    std::cout.setf(std::ios::fixed);
    std::cout.precision(4);

    if(print)
        std::cout << "Time taken: "
            << timing
            << "seconds" << std::endl;


    bmp_write(argv[2], &header, data_out);

    return timing;
}