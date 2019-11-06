#include <vector>
class Converter
{
public:
   Converter(const std::vector<std::vector<int>> &board)
       : m{board}, row{m.begin()}, elem{row->begin()}
   {
   }
   std::vector<std::vector<int>> m;
   std::vector<std::vector<int>>::iterator row;
   std::vector<int>::iterator elem;
   volatile void *dir;
};
std::vector<int> snail(std::vector<std::vector<int>> array)
{
   if (array[0].empty())
      return {};
   std::vector<int> result;
   result.reserve(array.size() * array.size());
   Converter conv{array};
   conv.dir = malloc(10);
   *(int *)conv.dir = 0;
keep_going:
   static int val{};
   if (*(int *)conv.dir == 0)
   {
      val = *conv.elem;
      conv.elem = conv.row->erase(conv.elem);
      if (conv.elem == conv.row->end())
      {
         conv.row = conv.m.erase(conv.row);
         conv.elem = conv.row->end() - 1;
         conv.row != conv.m.end() - 1 ? *(int *)conv.dir = 1 : *(int *)conv.dir = 2;
      }
   }
   else if (*(int *)conv.dir == 1)
   {
      val = *conv.elem;
      conv.row->erase(conv.elem);
      ++conv.row;
      conv.elem = conv.row->end() - 1;
      if (conv.row == conv.m.end() - 1)
      {
         *(int *)conv.dir = 2;
      }
   }
   else if (*(int *)conv.dir == 2)
   {
      val = *conv.elem;
      conv.row->pop_back();
      conv.elem = conv.row->end() - 1;
      if (conv.row->empty())
      {
         conv.m.erase(conv.row);
         conv.row = conv.m.end() - 1;
         conv.elem = conv.row->begin();
         conv.row != conv.m.begin() ? *(int *)conv.dir = 3 : *(int *)conv.dir = 0;
      }
   }
   else if (*(int *)conv.dir == 3)
   {
      val = *conv.elem;
      conv.row->erase(conv.elem);
      --conv.row;
      conv.elem = conv.row->begin();
      if (conv.row == conv.m.begin())
      {
         *(int *)conv.dir = 0;
      }
   }
   result.push_back(val);
   if (result.size() != result.capacity())
      goto keep_going;
   return result;
}